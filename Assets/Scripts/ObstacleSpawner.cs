using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance;
    [SerializeField] public Transform[] obstacleSpawn = new Transform[3];

    // Start is called before the first frame update
    void Start()
    {
        //SpawnObstacles();
    }

    // adicionar object pooling
    public void SpawnObstacles()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }

        int obstacleSpawnIndex = Random.Range(0, 3);
        Transform spawnPoint = obstacleSpawn[obstacleSpawnIndex];

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
