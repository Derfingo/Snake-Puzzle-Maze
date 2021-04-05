using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    //public AudioClip[] MusicClips;
    //public AudioClip[] SfxClips;

    public AudioSource FxSource;
    public AudioSource MusicSource;

    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<AudioManager>();
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

    public void PlaySingle(AudioClip clip)
    {
        FxSource.clip = clip;
        FxSource.Play();
    }

    public void RandomizeMusic(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        MusicSource.clip = clips[randomIndex];
        MusicSource.Play();
    }
}
