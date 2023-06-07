using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_InputField nameText;
    public ScoreMan scoreManager;

    public void ShowScore()
    {
        int score = 0;
        string name = "NovaDa";
        PlayerPrefs.SetString("Name", name);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        
    }


}
