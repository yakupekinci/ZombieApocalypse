using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeMonkey.Utils;
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
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
            if (row.rank.text == 1.ToString())
            {
                row.trophy.color = UtilsClass.GetColorFromString("FFD200");
            }
            else if (row.rank.text == 2.ToString())
            {
                row.trophy.color = UtilsClass.GetColorFromString("C6C6C6");
            }
            else if (row.rank.text == 3.ToString())
            {
                row.trophy.color = UtilsClass.GetColorFromString("B76F56");
            }
            else
            {
                row.trophy.gameObject.SetActive(false);
            }


        }
    }
}
