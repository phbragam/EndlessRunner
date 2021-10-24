using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groudTile;
    Vector3 nextSpawnPoint;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groudTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<ObstacleSpawner>().SpawnObstacles();
            temp.GetComponent<CoinSpawner>().SpawnCoins();
        }
    }
}
