using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private float masterVolume, musicVolume, sfxVolume;
    private float masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider;
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x "+ resolutions[i].height +" @ " +resolutions[i].refreshRate + " Hz";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
               resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
               }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        LoadAudioSettings();
    }

    public void SetMasterVolume(float volume) {
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolumeSlider", volume);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolumeSlider", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume) {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolumeSlider", volume);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetAudioMixerVolume(string type, float volume)
    {
        audioMixer.SetFloat(type, volume);
    }

    public void LoadAudioSettings()
    {
        SetAudioMixerVolume("master", PlayerPrefs.GetFloat("masterVolume", 0.7f));
        SetAudioMixerVolume("music", PlayerPrefs.GetFloat("musicVolume", 0.7f));
        SetAudioMixerVolume("sfx", PlayerPrefs.GetFloat("sfxVolume", 0.7f));
        LoadAudioSliderSettings();
    }

    public void LoadAudioSliderSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolumeSlider", 0.7f);
        musicSlider.value = PlayerPrefs.GetFloat("musicVolumeSlider", 0.7f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolumeSlider", 0.7f);
    }


    
}
