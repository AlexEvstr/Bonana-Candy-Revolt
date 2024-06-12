using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _pauseBtn;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void PauseGame()
    {
        _pauseWindow.SetActive(true);
        _pauseBtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pauseWindow.SetActive(false);
        _pauseBtn.SetActive(true);
        Time.timeScale = 1;
    }
}