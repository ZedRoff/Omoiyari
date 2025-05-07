using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class OptionMenuManager : MonoBehaviour
{
    [Header("Tabs")]
    public GameObject audioTab;
    public GameObject controlsTab;
    public GameObject firstSelectedButton;


    [Header("Audio Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null); // reset d'abord
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        ShowAudioTab();
        LoadAudioSettings();
    }

    public void ShowAudioTab()
    {
        audioTab.SetActive(true);
        controlsTab.SetActive(false);
    }

    public void ShowControlsTab()
    {
        audioTab.SetActive(false);
        controlsTab.SetActive(true);
    }

    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void LoadAudioSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    public void BackToMenu()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
    }
}
