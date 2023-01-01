using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;
    public AudioMixer audioMixer;
    public Toggle fullScreenToggle, fpsToggle;
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
    bool resolutionChanged = false;

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
        if (intToBool(PlayerPrefs.GetInt("resChanged")))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("resolutionIndex");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
        }
        resolutionDropdown.RefreshShownValue();

        LoadVideoSettings();
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

    public void ToggleFullscreen() {
        Screen.fullScreen = fullScreenToggle.isOn;
        PlayerPrefs.SetInt("isFullscreen", boolToInt(fullScreenToggle.isOn));
    }

    public void SetResolution (int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        PlayerPrefs.SetInt("width", resolution.width);
        PlayerPrefs.SetInt("height", resolution.height);
        resolutionChanged = true;
        PlayerPrefs.SetInt("resChanged", boolToInt(resolutionChanged));
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

    public void LoadVideoSettings()
    {
        LoadResolution();
        LoadFullScreenMode();
        LoadFPS();
    }

    public void LoadAudioSliderSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolumeSlider", 0.7f);
        musicSlider.value = PlayerPrefs.GetFloat("musicVolumeSlider", 0.7f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolumeSlider", 0.7f);
    }

    public void LoadFullScreenMode()
    {
        if (PlayerPrefs.HasKey("isFullscreen"))
        {
            fullScreenToggle.isOn = intToBool(PlayerPrefs.GetInt("isFullscreen"));
        }
    }

    public void LoadResolution()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("width"), PlayerPrefs.GetInt("height"), intToBool(PlayerPrefs.GetInt("isFullscreen")));
    }

    public void LoadFPS()
    {
        if (PlayerPrefs.HasKey("fpsToggle"))
        {
            fpsToggle.isOn = intToBool(PlayerPrefs.GetInt("fpsToggle"));
        }
    }

    public void ToggleFPS()
    {
        GameObject fps = GameObject.Find("FPSCanvas").transform.GetChild(0).gameObject;

        fps.SetActive(fpsToggle.isOn);
        PlayerPrefs.SetInt("fpsToggle", boolToInt(fpsToggle.isOn));

    }

    private int boolToInt(bool value)
    {
        if (value)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private bool intToBool(int value)
    {
        return value == 1;
    }

    
}
