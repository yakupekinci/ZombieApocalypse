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
         score = PlayerPrefs.GetInt("Score", 0);
    }

    private void Update()
    {
        if (timerText != null)
        {
            timerText.text = "Next Wave: " + zombieSpawner.time.ToString("F2");
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
         PlayerPrefs.SetInt("Score", score);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
