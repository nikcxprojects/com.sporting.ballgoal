using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    [Header("Settings References")]
    [SerializeField] private Text _audioText;
    [SerializeField] private Text _vibrationText;
    [SerializeField] private Text _musicText;


    private void Awake()
    {
        AudioLoader();
    }

    #region Settings
    public void ChangeAudio()
    {
        if (PlayerPrefs.GetString(PrefsKey.audio) == "Enable")
        {
            PlayerPrefs.SetString(PrefsKey.audio, "Disable");
            AudioManager.instance.EnableAudio(false);
            _audioText.text = "off";
        }
        else
        {
            PlayerPrefs.SetString(PrefsKey.audio, "Enable");
            AudioManager.instance.EnableAudio(true);
            _audioText.text = "on";
        }
    }

    public void ChangeMusic()
    {
        if (PlayerPrefs.GetString(PrefsKey.music) == "Enable")
        {
            PlayerPrefs.SetString(PrefsKey.music, "Disable");
            AudioManager.instance.EnableMusic(false);
            _musicText.text = "off";
        }
        else
        {
            PlayerPrefs.SetString(PrefsKey.music, "Enable");
            AudioManager.instance.EnableMusic(true);
            _musicText.text = "on";
        }
    }

    public void ChangeVibration()
    {
        if (PlayerPrefs.GetString(PrefsKey.vibration) == "Enable")
        {
            PlayerPrefs.SetString(PrefsKey.vibration, "Disable");
            _vibrationText.text = "off";
            AudioManager.instance.isVibration = false;

        }
        else
        {
            PlayerPrefs.SetString(PrefsKey.vibration, "Enable");
            _vibrationText.text = "on";
            AudioManager.instance.isVibration = true;

        }
    }

    private void AudioLoader()
    {
        if (!PlayerPrefs.HasKey(PrefsKey.audio)) PlayerPrefs.SetString(PrefsKey.audio, "Enable");
        if (!PlayerPrefs.HasKey(PrefsKey.vibration)) PlayerPrefs.SetString(PrefsKey.vibration, "Enable");
        if (!PlayerPrefs.HasKey(PrefsKey.music)) PlayerPrefs.SetString(PrefsKey.music, "Enable");

        if (PlayerPrefs.GetString(PrefsKey.audio) == "Enable")
        {
            AudioManager.instance.EnableAudio(true);
            _audioText.text = "on";
        }
        else
        {
            AudioManager.instance.EnableAudio(false);
            _audioText.text = "off";
        }

        if (PlayerPrefs.GetString(PrefsKey.music) == "Enable")
        {
            AudioManager.instance.EnableMusic(true);
            _musicText.text = "on";
        }
        else
        {
            AudioManager.instance.EnableMusic(false);
            _musicText.text = "off";
        }

        if (PlayerPrefs.GetString(PrefsKey.vibration) == "Enable")
        {
            AudioManager.instance.isVibration = true;
            _vibrationText.text = "on";
        }
        else
        {
            AudioManager.instance.isVibration = false;
            _vibrationText.text = "off";
        }
    }

    #endregion
}