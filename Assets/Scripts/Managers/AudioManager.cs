using UnityEngine.Audio;
using System;
using UnityEngine;

//Credit to Brackeys youtube tutorial on Audio managers, as the majority of this code and learning how to use it was made by him.
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(-3, 3)]
    public float pitch = 1;
    public bool loop = false;
    public AudioSource source;
    public float spatialBlend; 

    public Sound()
    {
        volume = 1;
        pitch = 1;
        loop = false;
        spatialBlend = 1; 
    }
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;
    //AudioManager

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            if (!s.source)
                s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }

    public void StopAll()
    {
        foreach (var s in sounds)
        {
            if (s.source.isPlaying)
                s.source.Stop();
        }
    }

}