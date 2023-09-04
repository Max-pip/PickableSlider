using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public static Action<GameObject> OnWarpEffectAdded;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private UI _UI;

    [SerializeField] private GameObject _warpEffect;

    public bool isGameRun;
    private bool _isGameStart = false;

    public void Initialization()
    {
        Instance = this;

        isGameRun = false;
        _isGameStart = false;
    }

    private void Update()
    {
        if (isGameRun)
        {
            return;
        }

#if UNITY_EDITOR
        SwipeToStart();
#endif

#if UNITY_ANDROID
        SwipeToStartMobile();
#endif
    }

    private void SwipeToStart()
    {
        if (Input.GetMouseButton(0) && !_isGameStart)
        {
            StartGame();
        }
    }

    private void SwipeToStartMobile()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !_isGameStart)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        _UI.StartPanelOff();
        isGameRun = true;
        OnWarpEffectAdded?.Invoke(_warpEffect);
        _isGameStart = true;
    }

    public void EndGame()
    {
        _UI.EndPanel();
        isGameRun = false;
    }
}
