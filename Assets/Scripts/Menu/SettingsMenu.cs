using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider volumeSlider;
    public TMP_Dropdown qualityDropDown;
    public Toggle fullScreenToggle;
    private int screenInt;

    private bool isFullScreen = false;

    const string prefName = "optionvalue";


    void Awake()
    {
        screenInt = PlayerPrefs.GetInt("ToggleState");

        if (screenInt == 1)
        {
            isFullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
        }

        qualityDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, qualityDropDown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("SliderValue", 1f);
        qualityDropDown.value = PlayerPrefs.GetInt(prefName, 2);
    }

    /* void Start()
    {
        if (!PlayerPrefs.HasKey("firstTime"))
        {
            AudioListener.volume = defaultVol;
            volumeSlider.value = PlayerPrefs.GetFloat("SliderValue", defaultVol);
            PlayerPrefs.SetInt("firstTime", 0);
        } 
    } */

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("SliderValue", volume);
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (isFullScreen == false)
        {
            PlayerPrefs.SetInt("ToggleState", 0);
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt("ToggleState", 1);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}