using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Game references")]
    [SerializeField] private GameObject _stickman;
    [SerializeField] private PlayerCube _startCube;
    [SerializeField] private Transform _cubesHolderPosition;
    [Header("Prefabs")]
    [SerializeField] private PlayerCube _cubePrefab;
    [SerializeField] private GameObject _pickUpTextEffect;
    [SerializeField] private ParticleSystem _pickUpEffect;
    [Header("Modifiers")]
    [SerializeField] private Vector3 _warpEffectPosition = new Vector3(0, 0, 40f);
    [SerializeField] private float _textEffectTargetHeight = 4f;
    [SerializeField] private float _durationToTargetHeight = 1.5f;
    [SerializeField] private float _jumpModifier = 1.7f;
    [Header("Cubes")]
    [SerializeField] private List<GameObject> _cubes;
    private PlayerAnimation _playerAnimation;

    public void Initialization()
    {
        _startCube.Initialization();
        _cubes.Add(_startCube.gameObject);
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    private void OnEnable()
    {
        PickUpCube.OnCubesPickUp += CubePickUp;
        GameManager.OnWarpEffectAdded += AddWarpEffect;
    }

    private void OnDisable()
    {
        PickUpCube.OnCubesPickUp -= CubePickUp;
        GameManager.OnWarpEffectAdded -= AddWarpEffect;
    }

    #region GamePlayMethods
    private void CubePickUp()
    {
        JumpStickman();
        SpawnCube();
        PickUpEffect();
        PickUpTextEffect();
    }

    private void JumpStickman()
    {
        _playerAnimation.JumpAnimation();       
        Vector3 vectorUpStickman = new Vector3(_stickman.transform.localPosition.x, _stickman.transform.localPosition.y + _jumpModifier, _stickman.transform.localPosition.z);
        _stickman.transform.localPosition = vectorUpStickman;       
    }

    private void SpawnCube()
    {
        Vector3 spawnCubePosition = new Vector3(_cubesHolderPosition.position.x, _cubes.Count + _cubePrefab.transform.localScale.y / 2f, _cubesHolderPosition.position.z);
        PlayerCube playerCube = Instantiate(_cubePrefab, spawnCubePosition, Quaternion.identity);
        playerCube.transform.SetParent(_cubesHolderPosition);
        playerCube.Initialization();
        _cubes.Add(playerCube.gameObject);
    }

    private void PickUpEffect()
    {
        ParticleSystem pickUpEffect = Instantiate(_pickUpEffect, _stickman.transform.position, Quaternion.identity);
        Destroy(pickUpEffect.gameObject, 1f);
    }

    private void PickUpTextEffect()
    {
        GameObject pickUpEffect = Instantiate(_pickUpTextEffect, _stickman.transform.position, Quaternion.identity);
        float targetHeight = pickUpEffect.transform.position.y + _textEffectTargetHeight;
        pickUpEffect.transform.DOMoveY(targetHeight, _durationToTargetHeight);
        Destroy(pickUpEffect.gameObject, 3f);
    }

    private void AddWarpEffect(GameObject warpEffect)
    {
        GameObject objWarpEffect = Instantiate(warpEffect);
        objWarpEffect.transform.SetParent(transform);
        objWarpEffect.transform.position = _warpEffectPosition;
    }

    public void HitWall(GameObject playerCube)
    {
        Handheld.Vibrate();
        _cubes.Remove(playerCube);
        playerCube.transform.parent = null;
        if (_cubes.Count == 0 ) 
        {
            GameManager.Instance.EndGame();
        }
    }
    #endregion
}
