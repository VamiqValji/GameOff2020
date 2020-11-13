using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // BIRD PREFABS
    public GameObject BirdLeftPrefab;
    public GameObject BirdRightPrefab;
    public Transform Player;
    private int randNum;
    private int randNumClouds;
    private float Timer;
    private float TimerClouds;
    public int WaitingTime = 1;
    public int WaitingTimeClouds = 4;
    private bool CanSpawnClouds;
    private bool canSpawn = true;
    private GameObject[] Enemy;
    //CLOUD PREFABS
    public GameObject CloudBig;
    public GameObject CloudSmall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // BIRD TIMER
        Timer += Time.deltaTime;
        if (Timer > WaitingTime)
        {
            Debug.Log(WaitingTime + " second(s) elapsed.");
            canSpawn = true;
            Timer = 0;
        }
        TimerClouds += Time.deltaTime;
        if (TimerClouds > WaitingTimeClouds)
        {
            Debug.Log(WaitingTimeClouds + " second(s) elapsed.");
            CanSpawnClouds = true;
            TimerClouds = 0;
        }
        // BIRD SPAWN
        if (Player.transform.position.y < 100)
        {
            //Debug.Log("working outer");
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
        // CLOUD SPAWN
        if (Player.transform.position.y < 70)
        {
            if (Mathf.Round(Player.transform.position.y) % 5 == 0 && Player.transform.position.y != 0)
            {
                if (CanSpawnClouds == true)
                {
                    SpawnClouds();
                    CanSpawnClouds = false;
                }
            }
        }
    }

    public void SpawnBird()
    {
        //Debug.Log("test123");
        randNum = Random.Range(1, 3);
        //Debug.Log(randNum);
        if (randNum == 1)
        {
            //Debug.Log("bird spawned");
            Instantiate(BirdLeftPrefab, new Vector2(9, Player.transform.position.y + 10), transform.rotation);
            Debug.Log(Player.transform.position.y + 10);
        }
        else // randNum
        {
            //Debug.Log("bird spawned");
            Instantiate(BirdRightPrefab, new Vector2(-9, Player.transform.position.y + 10), transform.rotation);
            Debug.Log(Player.transform.position.y + 10);
        }
    }
    public void PlayerDeath () // Destroys bird game objects
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemies in Enemy)
        {
            Destroy(Enemies);
        } 
    }
    public void SpawnClouds()
    {
        randNumClouds = Random.Range(1, 3);
        //Debug.Log(randNumClouds);
        if (randNumClouds == 1)
        {
            //Debug.Log("cloud spawned");
            Instantiate(CloudBig, new Vector2(9, Player.transform.position.y + 7), transform.rotation);
            Debug.Log(Player.transform.position.y + 10);
        }
        else // randNumClouds
        {
            //Debug.Log("cloud spawned");
            Instantiate(CloudSmall, new Vector2(-9, Player.transform.position.y + 7), transform.rotation);
            Debug.Log(Player.transform.position.y + 10);
        }
    }
}
