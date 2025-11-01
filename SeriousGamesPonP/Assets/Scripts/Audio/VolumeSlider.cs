using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MUSIC_PREF_KEY = "MusicVolumePref";
    private const string SFX_PREF_KEY   = "SFXVolumePref";

    private void Start()
    {
        // Load saved slider values (with default of 1 if none saved)
        float musicValue = PlayerPrefs.GetFloat(MUSIC_PREF_KEY, 1f);
        float sfxValue   = PlayerPrefs.GetFloat(SFX_PREF_KEY, 1f);

        // Set slider values (this may trigger OnValueChanged if you set up listeners)
        musicSlider.value = musicValue;
        sfxSlider.value   = sfxValue;

        // Apply them to mixer
        SetMusicVolume(musicValue);
        SetSFXVolume(sfxValue);
    }

    public void OnMusicSliderChanged()
    {
        float volume = musicSlider.value;
        SetMusicVolume(volume);

        // Save preference
        PlayerPrefs.SetFloat(MUSIC_PREF_KEY, volume);
        PlayerPrefs.Save();
    }

    private void SetMusicVolume(float volume)
    {
        // Avoid taking log of zero or negative
        if (volume > 0f)
            myMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        else
            myMixer.SetFloat("MusicVolume", -80f); // essentially silent
    }

    public void OnSFXSliderChanged()
    {
        float volume = sfxSlider.value;
        SetSFXVolume(volume);

        // Save preference
        PlayerPrefs.SetFloat(SFX_PREF_KEY, volume);
        PlayerPrefs.Save();
    }

    private void SetSFXVolume(float volume)
    {
        if (volume > 0f)
            myMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        else
            myMixer.SetFloat("SFXVolume", -80f);
    }
}
