using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBottomSideCheck : MonoBehaviour
{
    private float highscore; // For this level
    private float score;
    public float distance = 10f;
    public Transform player;
    public Transform bottomSideCheck;
    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        highscore = 0;
        score = 0;
        respawnPoint = new Vector3(8, player.position.y - distance, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = player.position.y;
        if (score < 0)
        {
            score = 0;
            highscore = 0;
            bottomSideCheck.position = respawnPoint;
        }
        if (score > highscore)
        {
            highscore = score;
            //Debug.Log(new Vector3(bottomSideCheck.position.x, bottomSideCheck.position.y - distance, bottomSideCheck.position.z));
            bottomSideCheck.localPosition = new Vector3(8, player.position.y - distance, 0);
        }
    }
}
