using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMenuManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject GameWonPanel;
    public GameObject PauseMenuPanel;

    private static GameObject staticGameOver;

    private void Awake()
    {
        if (GameOverPanel == null)
        {
            staticGameOver = GameOverPanel;
        }
    }

    public static void GameOver()
    {
        staticGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public static void Restart()
    {
        staticGameOver.SetActive(false);
        Time.timeScale = 1f;
    }
}
