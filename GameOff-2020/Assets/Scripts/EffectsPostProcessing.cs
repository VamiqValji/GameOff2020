﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectsPostProcessing : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette Vignette;
    private float VignetteDefault = 0.288f;
    private float VignetteActive = 0f;

    //private Bloom Bloom;
    //private float BloomDefault = 0.288f;
    //private float BloomActive = 0f;

    //private DepthOfField DoF;
    //private float DoFDefault = 0f;
    //private float DoFActive = 78f;

    private ChromaticAberration Chromatic;
    private float ChromaticDefault = 0.1f;
    private float ChromaticActive = 1f;

    public RocketController PlayerScript;

    // Timer
    private float Timer;
    public int WaitingTime = 7; // Seconds
    private bool StarActive;
    // Start is called before the first frame update
    void Start()
    {
        StarActive = false;
        volume.profile.TryGetSettings(out Vignette); // Pushes whatever the value is, if on
        Vignette.intensity.value = VignetteDefault;

        //volume.profile.TryGetSettings(out Bloom);
        //Bloom.intensity.value = BloomDefault;

        //volume.profile.TryGetSettings(out DoF);
        //DoF.focalLength.value = DoFDefault;

        volume.profile.TryGetSettings(out Chromatic);
        Chromatic.intensity.value = ChromaticDefault;

    }

    // Update is called once per frame
    void Update()
    {
        // STAR ACTIVE
        if (StarActive == true)
        {
            Timer += Time.deltaTime;
            if (Timer > WaitingTime)
            {
                Debug.Log(WaitingTime + " second(s) elapsed.");
                StarActive = false;
                PlayerScript.StarPowerUpReset();
                Timer = 0;
            }
        }

        // CHANGE EFFECTS BASED ON IF POWERUP IS ACTIVE

        if (StarActive == false && Vignette.intensity.value != VignetteDefault)
        {
            Vignette.intensity.value = Mathf.Lerp(Vignette.intensity.value, VignetteDefault, 2f * Time.deltaTime); // start value, end value, over time
        }
        if (StarActive == true && Vignette.intensity.value != VignetteActive)
        {
            Vignette.intensity.value = Mathf.Lerp(Vignette.intensity.value, VignetteActive, 1.5f * Time.deltaTime); // start value, end value, over time
        }

        if (StarActive == false && Chromatic.intensity.value != ChromaticDefault)
        {
            Chromatic.intensity.value = Mathf.Lerp(Chromatic.intensity.value, ChromaticDefault, 2f * Time.deltaTime); // start value, end value, over time
        }
        if (StarActive == true && Vignette.intensity.value != VignetteActive)
        {
            Chromatic.intensity.value = Mathf.Lerp(Chromatic.intensity.value, ChromaticActive, 1.5f * Time.deltaTime); // start value, end value, over time
        }

        //Vignette.intensity.value = Mathf.Lerp(Vignette.intensity.value, 1, 0.5f * Time.deltaTime); // start value, end value, over time
    }

    public void StarPowerUp()
    {
        StarActive = true;
    }
    public void Die()
    {
        Vignette.intensity.value = VignetteDefault;
        Chromatic.intensity.value = ChromaticDefault;
        StarActive = false;
    }
}