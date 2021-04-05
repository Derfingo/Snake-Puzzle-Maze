using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject audioManager;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(gameManager);
        }

        if (AudioManager.Instance == null)
        {
            Instantiate(audioManager);
        }
    }
}
