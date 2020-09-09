using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject PauseMenuPanel;
    public GameObject GameMenu;
    

    private static GameObject PauseMenuPanelStatic;
    private static GameObject gameOverPanelStatic;
    private static GameObject gameMenuStatic;
    

    public bool IsPaused = false;

    private void Awake()
    {
        if (gameOverPanelStatic == null)
        {
            gameOverPanelStatic = GameOverPanel;
        }

        if (PauseMenuPanelStatic == null)
        {
            PauseMenuPanelStatic = PauseMenuPanel;
        }

        if (gameMenuStatic == null)
        {
            gameMenuStatic = GameMenu;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void FailGame()
    {
        gameOverPanelStatic.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnPauseGame()
    {
        gameMenuStatic.SetActive(true);
        PauseMenuPanelStatic.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void OnResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenuPanelStatic.SetActive(false);
        gameMenuStatic.SetActive(false);
        IsPaused = false;
    }
}
