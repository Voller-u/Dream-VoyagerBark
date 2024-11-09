using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingUI : UIBase
{
    public Slider MusicVolumeSlider;
    public Slider SoundVolumeSlider;

    public Button SaveAndExit;
    public Button Exit;

    private void Awake()
    {
        MusicVolumeSlider.onValueChanged.AddListener((float volume) =>
        {
            MusicVolumeSlider.value = volume;
            SoundManager.Instance.BGMVolume = volume;
        });

        SoundVolumeSlider.onValueChanged.AddListener(volume =>
        {
            SoundVolumeSlider.value = volume;
            SoundManager.Instance.SoundVolume = volume;
        });

        Exit.onClick.AddListener(() =>
        {
            EventManager.Instance.LoadScene("MainMenu");
        });
    }

    private void OnEnable()
    {
        int id = SceneManager.GetActiveScene().buildIndex;
        switch (id)
        {
            case 0:
                SaveAndExit.gameObject.SetActive(false);
                Exit.gameObject.SetActive(false);
                break;
            case 1:
                SaveAndExit.gameObject.SetActive(true);
                Exit.gameObject.SetActive(true);
                break;
        }
    }
}
