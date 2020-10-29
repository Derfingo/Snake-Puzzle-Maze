using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject gameOver;
    public GameObject pauseMenu;
    public GameObject buttonPauseMenu;

    public void OnGameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameIsPaused = false;
    }

    private void OnPauseGame()
    {
        pauseMenu.SetActive(true);
        buttonPauseMenu.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void OnResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        buttonPauseMenu.SetActive(true);
        gameIsPaused = false;
    }

    private void OnMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
