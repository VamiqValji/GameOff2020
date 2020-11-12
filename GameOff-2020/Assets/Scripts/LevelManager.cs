﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject BirdLeftPrefab;
    public GameObject BirdRightPrefab;
    public Transform Player;
    private int randNum;
    private float Timer;
    public int WaitingTime = 3;
    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TIMER
        Timer += Time.deltaTime;
        if (Timer > WaitingTime)
        {
            Debug.Log("3 seconds elapsed.");
            Timer = 0;
            canSpawn = true;
        }
        // BIRD SPAWN
        if (Player.transform.position.y < 1000)
        {
            Debug.Log("working outer");

            //Debug.Log(Mathf.Round(rb.position.y));
            if (Mathf.Round(Player.transform.position.y) % 5 == 0 && Player.transform.position.y != 0)
            {
                if (canSpawn == true)
                {
                    SpawnBird();
                    canSpawn = false;
                }
            }
        }
    }
    public void SpawnBird()
    {
        Debug.Log("test123");
        randNum = Random.Range(1, 2);
        Debug.Log(randNum);
        if (randNum == 1)
        {
            Debug.Log("spawned");
            Instantiate(BirdLeftPrefab, new Vector2(18, Player.transform.position.y + 10), transform.rotation);
            Debug.Log(Player.transform.position.y + 10);
        }
        else // randNum == 2
        {
            Debug.Log("spawned");
            Instantiate(BirdRightPrefab, new Vector2(-18, Player.transform.position.y + 10), transform.rotation);
            Debug.Log(Player.transform.position.y + 10);
        }
    }
}
