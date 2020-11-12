using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform BirdLeftPrefab;
    public Transform BirdRightPrefab;
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
        Timer += Time.deltaTime;
        if (Timer > WaitingTime)
        {
            Debug.Log("3 seconds elapsed");
            Timer = 0;
            canSpawn = true;
        }
    }
    public void SpawnBird(float PlayerPos)
    {
        if (canSpawn == true)
        {
            Debug.Log("test123");
            randNum = Random.Range(1, 2);
            if (randNum == 1)
            {
                Debug.Log("spawned");
                Instantiate(BirdLeftPrefab, new Vector2(18, PlayerPos + 25), transform.rotation);
            }
            else // randNum == 2
            {
                Debug.Log("spawned");
                Instantiate(BirdRightPrefab, new Vector2(-18, PlayerPos + 25), transform.rotation);
            }

            Timer = 0;
            canSpawn = false;
        }
    }
}
