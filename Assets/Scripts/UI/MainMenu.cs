using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject GameOptionsPanel;
        [SerializeField] private GameObject StartScreenPanel;
        [SerializeField] private GameObject StartMenuPanel;
        [SerializeField] private GameObject ModesMenuPanel;

        public void OnPlayHandler()
        {
            SceneManager.LoadScene(1);
        }

        public void OnExitHandler()
        {
            Application.Quit();
        }

        public void OnStartMenu()
        {
            GameOptionsPanel.SetActive(false);
            StartScreenPanel.SetActive(true);
        }

        public void OnModesMenu()
        {
            StartMenuPanel.SetActive(false);
            ModesMenuPanel.SetActive(true);
        }

        public void OnGameOptions()
        {
            StartScreenPanel.SetActive(false);
            GameOptionsPanel.SetActive(true);
        }
    }
}