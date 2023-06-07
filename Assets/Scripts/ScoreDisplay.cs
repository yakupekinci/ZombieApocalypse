using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_InputField nameText;
    public ScoreMan scoreManager;

    public void Start()
    {
        int score = 0;
        string name = nameText.text;
        PlayerPrefs.SetString("Name",name);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();


    }


}
