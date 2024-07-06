using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject player, menu, pause, resume, leaderboard;
    public SpawnManager spawnManager;
    public PlayerScoreData playerScoreData;

   public void EndGame()
   {
        spawnManager.StopObstacleSpawn();
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Animator>().enabled = false;
        pause.SetActive(false);
        menu.SetActive(true);
        resume.SetActive(false);
        Debug.Log("game over");
        playerScoreData.CallPostScore();
   }

    public void Resume()
    {
        spawnManager.StartSpawning();
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Animator>().enabled = true;
    }
}
