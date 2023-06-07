using UnityEngine;

public class MYGameManager : MonoBehaviour
{
    public static MYGameManager Instance { get; private set; }

    public int currentScore;
    public string playerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        // Oyun bittiğinde bu fonksiyonu çağırın
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        string highscorePlayerName = PlayerPrefs.GetString("HighscorePlayerName", "");

        if (currentScore > highscore)
        {
            // Yeni en yüksek skoru kaydet
            PlayerPrefs.SetInt("Highscore", currentScore);
            PlayerPrefs.SetString("HighscorePlayerName", playerName);
            PlayerPrefs.Save();
        }
    }
}
