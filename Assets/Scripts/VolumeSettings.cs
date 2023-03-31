using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;


    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

     void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value); 
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }
    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

}
