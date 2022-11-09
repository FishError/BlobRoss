using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip clip;
    private void Start()
    {
        AudioManager.Instance.PlayMusic(clip);
    }
}
