using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class ScoreBoard : MonoBehaviour
{

    public TMP_Text text;
    public int score = 0;

    void Start()
    {
        text.SetText("Score: " + score.ToString());
    }

    public void setScore()
    {
        score++;
        text.SetText("Score: " + score.ToString());
    }
}
