using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public sealed class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManagerScript Instance;

    public void Initialize()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Instance.sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }
}
