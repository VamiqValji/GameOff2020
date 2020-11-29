using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSoundController : MonoBehaviour
{
    private float movement;
    private bool inGame = false;
    public GameObject RocketSound;
    public bool isDead = false;
    
    void Update()
    {
        if (isDead == false)
        {
            movement = Input.GetAxis("Horizontal");
            if (movement != 0)
            {
                if (inGame == false)
                {
                    //Instantiate(RocketSound, transform.position, transform.rotation);
                    RocketSound.SetActive(true);
                    inGame = true;
                }
            }
            else
            {
                if (inGame == true)
                {
                    //Destroy(GameObject.FindGameObjectWithTag("RocketSound"));
                    RocketSound.SetActive(false);
                    inGame = false;
                }
            }
        }
        else
        {
            RocketSound.SetActive(false);
        }
    }
}
