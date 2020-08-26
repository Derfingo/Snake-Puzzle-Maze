using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator animator;

    public GameObject GameOverPanel;
    public GameObject PauseMenuPanel;

    private static GameObject PauseMenuPanelStatic;
    private static GameObject gameOverPanelStatic;
    public static bool IsPaused = false;

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
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void FailGame()
    {
        gameOverPanelStatic.SetActive(true);
    }

    public void OnPauseGame()
    {
        IsPaused = true;
        PauseMenuPanelStatic.SetActive(true);
        Time.timeScale = 0f;
        animator.SetBool("IsTransition", true);
    }

    public void ONResumeGame()
    {
        IsPaused = false;
        PauseMenuPanelStatic.SetActive(false);
        Time.timeScale = 1f;
        animator.SetBool("IsTransition", false);
    }
}
