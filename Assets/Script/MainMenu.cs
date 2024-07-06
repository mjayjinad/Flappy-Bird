using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button start, quit;
    public TMP_InputField playerName;

    void Start()
    {
        start.onClick.AddListener(() => SartGame());
        quit.onClick.AddListener(() => QuitGame());
    }

    public void SartGame()
    {
        Debug.Log("Start");
        PlayerPrefs.SetString("name", playerName.text);
        SceneManager.LoadScene("FlappyBird");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
