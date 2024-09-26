using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;


    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        if(scoreText == null) { Debug.Log("score text null"); }
        scoreText.text = "Score: " + score;
    }
}
