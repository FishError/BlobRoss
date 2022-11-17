using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public static AudioManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
        MusicSource.loop = true;
    }

    public bool CheckClipIsPlaying(AudioClip clip)
    {
        return MusicSource.clip == clip && MusicSource.isPlaying;
    }
}
