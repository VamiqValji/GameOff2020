//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake() // Same as start but called beforehand
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); // 
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BillyTheGreat");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Find sound in sound array where sound.name is equal to the sound's name
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return; // Don't try playing a song that doesn't exist
        }
        s.source.Play();
    }
}
