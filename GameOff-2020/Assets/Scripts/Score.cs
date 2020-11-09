using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float highscore;
    public float score;
    public Transform player;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        highscore = 0;
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = player.position.y;
        if (score < 0)
        {
            score = 0;
        }
        if (score > highscore)
        {
            highscore = score;
            GetComponent<Highscore>().NewHighscore(highscore);
        }
        scoreText.text = (score* 10).ToString("0");
    }
    public void ScoreReset()
    {
        score = 0;
    }
}
