using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject GameOverPanel;
    private static GameObject gameOverPanelStatic;

    private void Awake()
    {

        if (gameOverPanelStatic == null)
        {
            gameOverPanelStatic = GameOverPanel;
        }

        IsPaused = false;
    }

    public void OnPlayHandler()
    {
        SceneManager.LoadScene(1);
    }
       
    public void OnExitHandler()
    {
        Application.Quit();
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void FailGame()
    {
        gameOverPanelStatic.SetActive(true);
        IsPaused = true;
    }
}
