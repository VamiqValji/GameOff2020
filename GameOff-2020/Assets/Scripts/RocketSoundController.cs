﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSoundController : MonoBehaviour
{
    private float movement;
    private bool inGame = false;
    public GameObject RocketSound;
    
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement != 0)
        {
            if (inGame == false)
            {
                Instantiate(RocketSound, transform.position, transform.rotation);
                inGame = true;
            }
        }
        else
        {
            if (inGame == true)
            {
                Destroy(GameObject.FindGameObjectWithTag("RocketSound"));
                inGame = false;
            }
        }
    }
}
