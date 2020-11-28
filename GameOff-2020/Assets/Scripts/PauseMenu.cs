using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;

    public AudioMixer audioMixer;

    private float previousVolume;

    public Highscore highscoreScript;

    // Start is called before the first frame update
    void Start()
    {
        //if (audioMixer.GetFloat("Volume"))
        //{

        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckIsPausedResume();
        }
    }

    public void CheckIsPausedResume()
    {
        if (IsPaused == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Menu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Will quit but not in Unity editor");
        Application.Quit();
    }

    public void VolumeOn()
    {
        audioMixer.SetFloat("Volume", previousVolume);
    }

    public void VolumeOff()
    {
        audioMixer.GetFloat("Volume", out previousVolume);
        audioMixer.SetFloat("Volume", -80f);
    }

    public void ResetHighscore()
    {
        highscoreScript.ResetHighscore();
    }
}
