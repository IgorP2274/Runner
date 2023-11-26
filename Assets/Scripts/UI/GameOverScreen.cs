using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _ganmeOverGroup;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;


    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }


    void Start()
    {
        _ganmeOverGroup.alpha = 0;
    }

    void Update()
    {
        
    }

    private void OnDied() 
    {
        _ganmeOverGroup.alpha = 1;
        Time.timeScale = 0;
    }
    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
