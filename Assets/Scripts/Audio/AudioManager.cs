using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SFXSource;
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

    public void PlayMusicAudio(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
        MusicSource.loop = true;
    }

    public void PlaySFXAudio(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();
        SFXSource.loop = false;
    }

    public bool CheckClipIsPlaying(AudioClip clip)
    {
        return MusicSource.clip == clip && MusicSource.isPlaying;
    }
}
