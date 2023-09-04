using UnityEngine;

public class GameBootstraper : MonoBehaviour
{
    [SerializeField] private TileGenerator _tileGenerator;
    [SerializeField] private UI _UI;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CameraShake _cameraShake;

    private void Awake()
    {
        _tileGenerator.Initialization();
        _UI.Initialization();
        _gameManager.Initialization();
        _playerController.Initialization();
        _playerInput.Initialization();
        _cameraShake.Initialization();
    }
}
