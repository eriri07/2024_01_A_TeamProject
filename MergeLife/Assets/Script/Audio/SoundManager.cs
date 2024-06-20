using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1.0f;
    [Range(0.1f, 3f)]
    public float pitch = 1.0f;
    public bool loop;
    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource sources;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public List<Sound> sounds = new List<Sound>();
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound sound in sounds)
        {
            sound.sources = gameObject.AddComponent<AudioSource>();
            sound.sources.clip = sound.clip;
            sound.sources.volume = sound.volume;
            sound.sources.pitch = sound.pitch;
            sound.sources.loop = sound.loop;
            sound.sources.outputAudioMixerGroup = sound.mixerGroup;
        }

    }

    public void PlaySound(string name)
    {
        Sound soundtoPlay = sounds.Find(sound => sound.name == name);
        if (soundtoPlay != null)
        {
            soundtoPlay.sources.Play();
        }
        else
        {
            Debug.Log("사운드 " + name + " 찾을 수 없다.");
        }
    }
}
