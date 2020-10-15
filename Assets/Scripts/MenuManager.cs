using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject PauseMenu;
    public GameObject ButtonPauseMenu;

    private static GameObject PauseMenuPanel;
    private static GameObject gameOverPanel;
    private static GameObject buttonPauseMenu;

    private void Awake()
    {
        if (buttonPauseMenu == null)
        {
            buttonPauseMenu = ButtonPauseMenu;
        }

        if (gameOverPanel == null)
        {
            gameOverPanel = GameOver;
        }

        if (PauseMenuPanel == null)
        {
            PauseMenuPanel = PauseMenu;
        }
    }

    public static void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public static void OnPauseGame()
    {
        PauseMenuPanel.SetActive(true);
        buttonPauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public static void OnResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenuPanel.SetActive(false);
        buttonPauseMenu.SetActive(true);
    }

    public static void OnMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
