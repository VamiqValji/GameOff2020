using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Highscore : MonoBehaviour
{
    public float highscore;
    public float score;
    public Transform player;
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        highscore = 0; // this will be the highscore's value if the player has not had a previous highscore
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = player.position.y;
        if (score < 0)
        {
            score = 0;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
        if (score > highscore)
        {
            highscore = score;
        }
        highscoreText.text = ("High Score: " + (highscore * 10).ToString("0"));
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("highscore", highscore);
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("highscore");
        highscore = 0f;
        highscoreText.text = ("High Score: " + "0");
        //PlayerPrefs.SetFloat("highscore", 0f);
    }
}
