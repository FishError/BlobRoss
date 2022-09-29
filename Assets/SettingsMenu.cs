using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume) {
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume) {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
    
}
