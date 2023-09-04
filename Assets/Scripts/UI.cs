using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private float _fadeDuration = 1f;

    private CanvasGroup _canvasGroup;

    public void Initialization()
    {
        _restartButton.onClick.AddListener(delegate
        {
            _levelManager.RestartLevel();
        });
        _startScreen.SetActive(true);
        _canvasGroup = _loseScreen.GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0.0f;
        _loseScreen.SetActive(false);
    }

    public void StartPanelOff()
    {
        _startScreen.SetActive(false);
    }

    public void EndPanel()
    {
        _loseScreen.SetActive(true);
        _canvasGroup.DOFade(1.0f, _fadeDuration);
    }
}
