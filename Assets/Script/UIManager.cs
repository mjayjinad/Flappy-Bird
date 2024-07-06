using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score, scoreValue;
    public Button pause, resume, restart, mainMenu, leaderboard;
    public Text scoreText;
    public GameObject menu, leaderboardUI;
    private GameOver gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<GameOver>();
        scoreText.GetComponent<Text>();
        pause.onClick.AddListener(() => PauseGame());
        restart.onClick.AddListener(() => RestartGame());
        resume.onClick.AddListener(() => ResumeGame());
        mainMenu.onClick.AddListener(() => MainMenu());
        leaderboard.onClick.AddListener(() => DisplayLeaderboard());
        Debug.Log(Time.timeScale);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("0");
    }

    public void UpdateScore()
    {
        score+= scoreValue;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        pause.gameObject.SetActive(false);
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        pause.gameObject.SetActive(true);
    }

    void DisplayLeaderboard()
    {
       leaderboardUI.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
