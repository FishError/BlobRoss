using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip clip;
    
    public void PlaySoundEffect(AudioClip clip)
    {
        if (!AudioManager.Instance.CheckClipIsPlaying(clip))
            AudioManager.Instance.PlaySFXAudio(clip);
    }
}
