using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MenuSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    
    void Start()
    {
        
    }
    public void SetResolution(int ResolutionOption)
    {
        string ResolutionOption1 = ResolutionOption.ToString();
        switch (ResolutionOption1)
        {
            case "0":
                Screen.SetResolution(1920, 1080, true);
                break;
            case "1":
                Screen.SetResolution(1600, 900, true);
                break;
            case "2":
                Screen.SetResolution(1366, 768, true);
                break;
            case "3":
                Screen.SetResolution(1280, 720, true);
                break;
            case "4":
                Screen.SetResolution(1024, 576, true);
                break;

        }
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityOption)
    {
        QualitySettings.SetQualityLevel(qualityOption);
    }
    public void SetFullscreen (bool isFullscreen)
    {
       Screen.fullScreen = isFullscreen;

    }
}
