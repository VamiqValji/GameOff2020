using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSoundController : MonoBehaviour
{
    private float movement;
    private bool inGame = false;
    public GameObject RocketSound;
    public bool isDead = false;
    public GameObject AndroidToggle;
    private bool Android = false;

    private void Start()
    {
        if (AndroidToggle.activeInHierarchy == true)
        {
            Android = true;
        }
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Android == true)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).position.x > Screen.width / 2)
                    {
                        movement = -1f;
                    }
                    else if (Input.GetTouch(0).position.x < Screen.width / 2)
                    {
                        movement = 1f;
                    }
                }
                else
                {
                    movement = 0f;
                }
            }
            else
            {
                movement = Input.GetAxis("Horizontal");
            }

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
