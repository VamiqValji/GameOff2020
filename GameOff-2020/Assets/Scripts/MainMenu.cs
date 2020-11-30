using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject clickSound;

    // MAIN MENU

    public void PlayGame ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
        Instantiate(clickSound);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // OPTIONS

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void click()
    {
        Instantiate(clickSound);
    }
}
