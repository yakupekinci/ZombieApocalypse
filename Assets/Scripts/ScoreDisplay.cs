using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text nameText;
    public ScoreMan scoreManager;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        var name = PlayerPrefs.GetString("Name",nameText.text);
        //scoreManager.AddScore(new Score(name, score));
    }
}
