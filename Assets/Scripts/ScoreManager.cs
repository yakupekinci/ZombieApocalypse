using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ZombieSpawner zombieSpawner;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    private int score = 0;


    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        timerText.text = "Next Wave: " + zombieSpawner.time.ToString("F2");

    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

