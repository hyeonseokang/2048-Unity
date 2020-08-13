using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private void Awake()
    {
        score = 0;
    }

    public void AddScore(int scoreNumber)
    {
        score += scoreNumber;
        scoreText.text = score.ToString();
    }

    public void Clear()
    {
        score = 0;
        AddScore(0);
    }
}
