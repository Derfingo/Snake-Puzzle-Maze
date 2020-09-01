using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayHandler()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitHandler()
    {
        Application.Quit();
    }
}
