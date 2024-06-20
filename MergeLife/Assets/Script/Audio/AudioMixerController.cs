using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider MusicMasterSlider;
    [SerializeField] private Slider MusicBGMSlider;
    [SerializeField] private Slider MusicSFXSlider;

    private void Awake()
    {
        MusicMasterSlider.onValueChanged.AddListener(SetMasterVolme);
        MusicBGMSlider.onValueChanged.AddListener(SetBGMVolme);
        MusicSFXSlider.onValueChanged.AddListener(SetSFXVolme);
    }
    public void SetMasterVolme(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetBGMVolme(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolme(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
}
