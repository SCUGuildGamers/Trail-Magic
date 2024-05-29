using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] FullscreenToggle fullscreenToggle;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeTextUI;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("gameVolume") && !PlayerPrefs.HasKey("fullscreenValue"))
        {
            PlayerPrefs.SetFloat("gameVolume", 1);
            PlayerPrefs.SetInt("fullscreenValue", 0);
            Load();
        }
        
        else if (!PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 1);
            Load();
        }
        else if(!PlayerPrefs.HasKey("fullscreenValue"))
        {
            PlayerPrefs.SetInt("fullscreenValue", 0);
            fullscreenToggle.isOn = false;
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
        AudioListener.volume = volumeSlider.value;

        fullscreenToggle.isOn = PlayerPrefs.GetInt("fullscreenValue") > 0;
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextUI.text = volume.ToString("0%");
        PlayerPrefs.SetFloat("gameVolume", volume);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        int fullScreen = Screen.fullScreen ? 0 : 1;
        PlayerPrefs.SetInt("fullscreenValue", fullScreen);
    }
}
