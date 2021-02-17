using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameAudio : MonoBehaviour
{
    private static GameAudio instance;
    public static GameAudio Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameAudio>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<GameAudio>();
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

    public AudioClip[] MusicClips;
    public AudioClip[] SfxClips;

    //private AudioSource musicSource;
    //private bool musicEnabled = true;

    //private bool sfxEnabled = true;

    
    
}
