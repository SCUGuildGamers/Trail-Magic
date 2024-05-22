using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Toggle fullscreenToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("fullScreenValue"))
        {
            PlayerPrefs.SetInt("fullScreenValue", 0);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        fullscreenToggle.isOn = (PlayerPrefs.GetInt("fullscreenValue") > 0);
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        int fullScreen = Screen.fullScreen ? 1 : 0;
        PlayerPrefs.SetInt("fullscreenValue", fullScreen);
    }
}
