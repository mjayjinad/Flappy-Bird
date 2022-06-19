using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button start, quit;

    void Start()
    {
        start.onClick.AddListener(() => SartGame());
        quit.onClick.AddListener(() => QuitGame());
    }

    public void SartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("FlappyBird");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
