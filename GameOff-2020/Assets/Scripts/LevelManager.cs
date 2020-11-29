using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform Player;
    private int randNum;
    private int randNumClouds;
    private int randNumStars;
    private float Timer;
    private float TimerClouds;
    public int WaitingTime = 1;
    public int WaitingTimeClouds = 4;
    private bool CanSpawnClouds;
    private bool CanSpawnStars;
    private bool canSpawn = true;
    private GameObject[] Enemy;
    // PREFABS
    public GameObject BirdLeftPrefab;
    public GameObject BirdRightPrefab;
    public GameObject CloudBig;
    public GameObject CloudSmall;
    public GameObject StarPrefab;
    public GameObject DemonLeftPrefab;
    public GameObject DemonRightPrefab;
    public GameObject UnicornLeft;
    public GameObject UnicornRight;
    public GameObject DemonCloudBig;
    public GameObject DemonCloudSmall;
    public GameObject UnicornCloudBig;
    public GameObject UnicornCloudSmall;
    public GameObject RightRainbowAttack;
    public GameObject LeftRainbowAttack;
    public GameObject HomingRainbowAttack;

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
            //Debug.Log(WaitingTime + " second(s) elapsed.");
            canSpawn = true;
            Timer = 0;
        }
        // CLOUD SPAWN
        TimerClouds += Time.deltaTime;
        if (TimerClouds > WaitingTimeClouds)
        {
            CanSpawnClouds = true;
            CanSpawnStars = true;
            TimerClouds = 0;
        }
        // BIRD SPAWN
        if (Player.transform.position.y < 90)
        {
            if (Mathf.Round(Player.transform.position.y) % 5 == 0 && Player.transform.position.y != 0)
            {
                if (canSpawn == true)
                {
                    SpawnBird();
                    canSpawn = false;
                }
            }
        }

        // DEMON SPAWN
        if (Player.transform.position.y > 170 && Player.transform.position.y < 270)
        {
            if (Mathf.Round(Player.transform.position.y) % 8 == 0) //  && Player.transform.position.y != 0
            {
                if (canSpawn == true)
                {
                    SpawnDemon();
                    canSpawn = false;
                }
            }
        }

        // UNICORN SPAWN
        if ((Player.transform.position.y > 360 && Player.transform.position.y < 420) || (Player.transform.position.y > 500))
        {
            if (Mathf.Round(Player.transform.position.y) % 5 == 0) //  && Player.transform.position.y != 0
            {
                if (canSpawn == true)
                {
                    SpawnUnicorn();
                    if (Player.transform.position.y > 500)
                    {
                        SpawnRainbow();
                        SpawnHomingRainbow();
                    }
                    canSpawn = false;
                }
            }
        }

        // CLOUD SPAWN
        if (Mathf.Round(Player.transform.position.y) % 3 == 0 && Player.transform.position.y != 0)
        {
            if (CanSpawnClouds == true)
            {
                SpawnClouds(Player.position.y);
                CanSpawnClouds = false;
            }
        }

        // STAR SPAWN
        if ((Player.transform.position.y < 70 && Player.transform.position.y != 0) || (Player.transform.position.y > 180 && Player.transform.position.y < 240) || (Player.transform.position.y > 350 && Player.transform.position.y < 400) || (Player.transform.position.y > 500))
        {
            if (Mathf.Round(Player.transform.position.y) % 5 == 0)
            {
                if (CanSpawnStars == true)
                {
                    SpawnStars();
                    CanSpawnStars = false;
                }
            }
        }

        //if (Mathf.Round(Player.transform.position.y) % 5 == 0 && Player.transform.position.y != 0)
        //{
        //    if (CanSpawnStars == true)
        //    {
        //        SpawnStars();
        //        CanSpawnStars = false;
        //    }
        //}

    }
    void FixedUpdate()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemies in Enemy)
        {
            if (Enemies.transform.position.y < (Player.transform.position.y - 10f))
            {
                Destroy(Enemies);
            }
        }
    }
    public void SpawnBird()
    {
        randNum = Random.Range(1, 3);
        if (randNum == 1)
        {
            Instantiate(BirdLeftPrefab, new Vector2(9, Player.transform.position.y + 10), transform.rotation);
        }
        else // randNum
        {
            //Debug.Log("bird spawned");
            Instantiate(BirdRightPrefab, new Vector2(-9, Player.transform.position.y + 10), transform.rotation);
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
    public void SpawnClouds(float playerPos)
    {
        var prefab = 1;
        if (playerPos < 180)
        {
            prefab = 1;
        }
        else
        {
            if (playerPos > 180 && playerPos < 360)
            {
                prefab = 2;
            }
            else
            {
                if (playerPos > 360)
                {
                    prefab = 3;
                }
            }
        }
        randNumClouds = Random.Range(1, 3);
        if (prefab == 1)
        {
            if (randNumClouds == 1)
            {
                Instantiate(CloudBig, new Vector2(9, Player.transform.position.y + 7), transform.rotation);
            }
            else // randNumClouds
            {
                Instantiate(CloudSmall, new Vector2(-9, Player.transform.position.y + 7), transform.rotation);
            }
        }
        else
        {
            if (prefab == 2)
            {
                if (randNumClouds == 1)
                {
                    Instantiate(DemonCloudBig, new Vector2(9, Player.transform.position.y + 7), transform.rotation);
                }
                else // randNumClouds
                {
                    Instantiate(DemonCloudSmall, new Vector2(-9, Player.transform.position.y + 7), transform.rotation);
                }
            }
            else
            {
                if (prefab == 3)
                {
                    if (randNumClouds == 1)
                    {
                        Instantiate(UnicornCloudBig, new Vector2(9, Player.transform.position.y + 7), transform.rotation);
                    }
                    else // randNumClouds
                    {
                        Instantiate(UnicornCloudSmall, new Vector2(-9, Player.transform.position.y + 7), transform.rotation);
                    }
                }
            }
        }
    }
    public void SpawnStars()
    {
        randNumStars = Random.Range(5, 8); //DEBUG MODE: 6, 8 // REGULAR: 1, 10
        if (randNumStars == 7)
        {
            Instantiate(StarPrefab, new Vector2(Random.Range(-8, 8), Player.transform.position.y + 7), transform.rotation);
        }
    }
    public void SpawnDemon()
    {
        randNum = Random.Range(1, 3);
        if (randNum == 1)
        {
            Instantiate(DemonLeftPrefab, new Vector2(7.5f, Player.transform.position.y + 10 + (randNum / 2)), transform.rotation);
        }
        else // randNum
        {
            //Debug.Log("bird spawned");
            Instantiate(DemonRightPrefab, new Vector2(-7.5f, Player.transform.position.y + 10 - (randNum / 2)), transform.rotation);
        }
    }
    public void SpawnUnicorn()
    {
        randNum = Random.Range(1, 3);
        if (randNum == 1)
        {
            Instantiate(UnicornLeft, new Vector2(7f, Player.transform.position.y + 10), UnicornLeft.transform.rotation);
        }
        else
        {
            Instantiate(UnicornRight, new Vector2(-7f, Player.transform.position.y + 10), UnicornRight.transform.rotation);
        }
    }
    public void SpawnRainbow()
    {
        var willSpawn = Random.Range(1, 3);

        if (willSpawn == 1)
        {
            randNum = Random.Range(1, 3);
            if (randNum == 1)
            {
                Instantiate(LeftRainbowAttack, new Vector2(7f, Player.transform.position.y + 10), LeftRainbowAttack.transform.rotation);
            }
            else
            {
                Instantiate(RightRainbowAttack, new Vector2(-7f, Player.transform.position.y + 10), RightRainbowAttack.transform.rotation);
            }
            // else don't spawn.
        }
    }
    public void SpawnHomingRainbow()
    {
        var willSpawn = Random.Range(1, 3);

        if (willSpawn == 1)
        {
            randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                Instantiate(HomingRainbowAttack, new Vector2(7f, Player.transform.position.y + 10), HomingRainbowAttack.transform.rotation);
            }
            else if (randNum == 2)  
            {
                Instantiate(HomingRainbowAttack, new Vector2(7f, Player.transform.position.y + 10), HomingRainbowAttack.transform.rotation);
                Instantiate(HomingRainbowAttack, new Vector2(-7f, Player.transform.position.y + 10), HomingRainbowAttack.transform.rotation);
            }
            else
            {
                Instantiate(HomingRainbowAttack, new Vector2(-7f, Player.transform.position.y + 10), HomingRainbowAttack.transform.rotation);
            }
        }
        // else don't spawn.
    }
}
