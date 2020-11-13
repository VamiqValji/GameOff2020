using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Highscore : MonoBehaviour
{
    public float highscore;
    public float score;
    public float highscoreForLevel;
    public Transform player;
    public Text highscoreText;
    public MiddleBottomSideCheck BottomSideCheckScript;

    // Start is called before the first frame update
    void Start()
    {
        highscoreForLevel = 0;
        highscore = 0;
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = player.position.y;
        if (score < 0)
        {
            highscoreForLevel = 0;
            score = 0;
        }
        if (score > highscore)
        {
            highscoreForLevel = score;
            BottomSideCheckScript.FollowPlayer(highscoreForLevel);
            //GetComponent<MiddleBottomSideCheck>().FollowPlayer();
            highscore = score;
        }
        highscoreText.text = (highscore * 10).ToString("0");
    }
}
