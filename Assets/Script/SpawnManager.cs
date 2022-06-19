using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObstaclePrefab;
    public List<GameObject> spawnedObstacle = new List<GameObject>();
    public float spawnPositionX = 22.0f;
    public float startTime = 3.0f;
    public float repeatTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnRandomObstacle", startTime, repeatTime);
    }

    void SpawnRandomObstacle()
    {
        int obstacleIndex = Random.Range(0, ObstaclePrefab.Length);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, 0);
        Instantiate(ObstaclePrefab[obstacleIndex], spawnPosition, ObstaclePrefab[obstacleIndex].transform.rotation);   
    }

    public void StopObstacleSpawn()
    {
        CancelInvoke();
        spawnedObstacle.AddRange(GameObject.FindGameObjectsWithTag("Obstacle"));
        foreach (GameObject go in spawnedObstacle)
        {
            go.GetComponent<MoveForward>().enabled = false;
        }
    }
}

