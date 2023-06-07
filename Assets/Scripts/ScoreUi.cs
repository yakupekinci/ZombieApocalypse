using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreMan scoreManager;

    void Start()
    {
        /* scoreManager.AddScore(new Score("Yakup", 5));
        scoreManager.AddScore(new Score("NOVADA", 15)); */

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (transform.childCount >= 10)
            {
                var lowestScoreRow = transform.GetChild(0).GetComponent<RowUi>();
                if (scores[i].score > float.Parse(lowestScoreRow.score.text))
                {
                    Destroy(lowestScoreRow.gameObject);
                    continue;
                }
            }

            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = (i + 1).ToString();
            row.Name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
