using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;

    public Transform[] obstacleSpawn = new Transform[3];

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacles()
    {
        int obstacleSpawnIndex = Random.Range(0, 3);
        Transform spawnPoint = obstacleSpawn[obstacleSpawnIndex];

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
