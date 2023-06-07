using UnityEngine;
using TMPro;

public class ScoreMan : MonoBehaviour
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
        if (timerText != null)
        {
            timerText.text = "Next Wave: " + zombieSpawner.time.ToString("F2");
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        MYGameManager.Instance.currentScore = score; // Score'u MYGameManager'a aktar
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
