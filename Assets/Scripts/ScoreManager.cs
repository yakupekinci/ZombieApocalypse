using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ZombieSpawner zombieSpawner;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public int score = 0;

    private void Start()
    {
        UpdateScoreText();
        
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
     
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
