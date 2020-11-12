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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnBird(float PlayerPos)
    {
        Timer += Time.deltaTime;
        if (Timer > WaitingTime)
        {

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
        }
    }
}
