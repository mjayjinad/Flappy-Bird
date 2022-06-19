using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject player, menu, pause, resume;
    public SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
   }

    public void Resume()
    {
        spawnManager.StartSpawning();
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Animator>().enabled = true;
    }
}
