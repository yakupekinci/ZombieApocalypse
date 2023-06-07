using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] StartGame startGame;
    public GameObject scoreDisplay;
    public GameObject mainMenuPanel;
    public GameObject difficultyPanel;
    public GameObject helpPanel;
    public GameObject score;
    public GameObject Player;
    public GameObject cameraa;
    public GameObject Canvas;
    public bool easy;
    public bool normal;
    public bool hard;
    public Texture2D cursorTexture; // İmleç için kullanılacak texture
    public CursorMode cursorMode = CursorMode.Auto; // İmleç modu

    public ScoreDisplay _scoreDisplay;
    private bool isMainMenuActive = true;

    void Start()
    {
        ShowMainMenu();
        Player.GetComponent<PlayerMovementScript>().enabled = false;
        Player.GetComponent<MouseLookScript>().enabled = false;
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        _scoreDisplay = FindObjectOfType<ScoreDisplay>();
        Cursor.visible = true;

        // Fare imleci etkinleştirilir
        Cursor.lockState = CursorLockMode.None; ;

    }

    public void ShowMainMenu()
    {
        scoreDisplay.SetActive(false);
        mainMenuPanel.SetActive(true);
        difficultyPanel.SetActive(false);
        helpPanel.SetActive(false);
        score.SetActive(false);

    }

    public void ShowDifficultyPanel()
    {
        mainMenuPanel.SetActive(false);
        difficultyPanel.SetActive(true);
        helpPanel.SetActive(false);
        score.SetActive(false);

    }

    public void ShowHelpPanel()
    {
        mainMenuPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        helpPanel.SetActive(true);
        score.SetActive(false);

    }

    public void ShowScorePanel()
    {
        mainMenuPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        helpPanel.SetActive(false);
        score.SetActive(true);

    }
    public void StartGame()
    {
        _scoreDisplay.ShowScore();
        //scoreDisplay.SetActive(true);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        PlayerPrefs.Save();

    }

    public void SetDifficultyEasy()
    {
        easy = true;
        Canvas.SetActive(false);
        Player.GetComponent<PlayerMovementScript>().enabled = true;
        Player.GetComponent<MouseLookScript>().enabled = true;
        cameraa.SetActive(false);
        Cursor.visible = false;



    }

    public void SetDifficultyMedium()
    {
        normal = true;
        Canvas.SetActive(false);
        Player.GetComponent<PlayerMovementScript>().enabled = true;
        Player.GetComponent<MouseLookScript>().enabled = true;
        cameraa.SetActive(false);
        Cursor.visible = false;



    }

    public void SetDifficultyHard()
    {
        hard = true;
        Canvas.SetActive(false);
        Player.GetComponent<PlayerMovementScript>().enabled = true;
        Player.GetComponent<MouseLookScript>().enabled = true;
        cameraa.SetActive(false);
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Main Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}