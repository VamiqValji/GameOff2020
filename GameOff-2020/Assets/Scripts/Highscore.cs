using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Highscore : MonoBehaviour
{
    public Text HighscoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewHighscore(highscore)
    {
        HighscoreText.text = (highscore * 10).ToString("0");
    }
}
