//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // Allows the class "Sound" we created to be seen in the Unity editor.
public class Sound // Does not derive from MonoBehavior; we are creating our own class. /*: MonoBehaviour*/
{
    public string name;

    public AudioClip clip; // holds the audio clip

    [Range(0f,1f)] // Slider in editor
    public float volume;

    [Range(0.1f, 3f)] // Slider in editor
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
