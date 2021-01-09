using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] protected GameObject SnakeAI;

        private void Start()
        {
            StartCoroutine(routine: CoroutineMethod());
        }

        private IEnumerator CoroutineMethod()
        {
            yield return new WaitForSeconds(3);

            SnakeAI.SetActive(true);
        }

        public void OnPlayHandler()
        {
            SceneManager.LoadScene(1);
        }

        public void OnExitHandler()
        {
            Application.Quit();
        }
    }
}