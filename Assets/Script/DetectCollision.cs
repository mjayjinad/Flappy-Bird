using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameOver gameOver;
    public UIManager uiManager;

    private void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOver.EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        uiManager.UpdateScore();
    }
}
