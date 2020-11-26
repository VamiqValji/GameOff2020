using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public float Pvolume;

    // MAIN MENU

    public void PlayGame ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Will quit but not in Unity editor");
        Application.Quit();
    }

    // OPTIONS

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        Pvolume = volume;
    }
}
