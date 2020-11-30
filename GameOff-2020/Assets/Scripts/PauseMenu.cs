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

    public Animator controlsUI;

    public GameObject clickSound;

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
        controlsUI.SetBool("Paused", false);
        Time.timeScale = 1f;
        IsPaused = false;
        Instantiate(clickSound);
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        controlsUI.SetBool("Paused", true);
        Time.timeScale = 0f;
        IsPaused = true;
        Instantiate(clickSound);
    }

    public void Menu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Instantiate(clickSound);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void VolumeOn()
    {
        audioMixer.SetFloat("Volume", previousVolume);
        Instantiate(clickSound);
    }

    public void VolumeOff()
    {
        audioMixer.GetFloat("Volume", out previousVolume);
        audioMixer.SetFloat("Volume", -80f);
    }

    public void click()
    {
        Instantiate(clickSound);
    }
}
