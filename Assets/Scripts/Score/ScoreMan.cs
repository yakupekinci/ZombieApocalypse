using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreMan : MonoBehaviour
{
    private ScoreData sd;

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
        if (sd.scores.Count > 10)
        {
            sd.scores = sd.scores.OrderByDescending(x => x.score).Take(10).ToList();
        }
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
}
