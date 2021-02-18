using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject GameSettings;
        [SerializeField] private GameObject MainScreen;
        [SerializeField] private GameObject MainMenu;
        [SerializeField] private GameObject ModesMenu;
        [SerializeField] private GameObject LevelsMenu;

        public void OnClassicGame()
        {
            SceneManager.LoadScene(1);
        }

        public void OnExit()
        {
            Application.Quit();
        }

        public void OnMainMenu()
        {
            GameSettings.SetActive(false);
            MainScreen.SetActive(true);
        }

        public void OnModesMenu()
        {
            MainMenu.SetActive(false);
            ModesMenu.SetActive(true);
        }

        public void OnLevelsMenu()
        {
            ModesMenu.SetActive(false);
            LevelsMenu.SetActive(true);
        }

        public void OnGameSettings()
        {
            MainScreen.SetActive(false);
            GameSettings.SetActive(true);
        }

        public void BackOnMainMenu()
        {
            ModesMenu.SetActive(false);
            LevelsMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}