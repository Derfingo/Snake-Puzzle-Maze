using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject GameOverPanel;
        [SerializeField] GameObject GameWonPanel;
        [SerializeField] GameObject PauseMenuPanel;

        [SerializeField] GameObject ButtonMenu;

        public static bool GameIsPaused = false;
        public static bool GameEnded = false;

        private static MenuManager instance = null;
        public static MenuManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<MenuManager>();
                    if (instance == null)
                    {
                        instance = new GameObject().AddComponent<MenuManager>();
                    }
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(obj: this);
                DontDestroyOnLoad(target: this);
            }
        }

        public void GameOver()
        {
            if (true)
            {
                GameEnded = true;
                GameOverPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        public void GameWon()
        {
            GameWonPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            GameEnded = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Pause()
        {
            PauseMenuPanel.SetActive(true);
            ButtonMenu.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void Resume()
        {
            PauseMenuPanel.SetActive(false);
            Time.timeScale = 1f;
            ButtonMenu.SetActive(true);
            GameIsPaused = false;
        }

        public void MainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
