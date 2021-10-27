using UnityEngine;

public sealed class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _groudTile;

    private Vector3 _nextSpawnPoint;

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

    // adicionar object pooling
    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(_groudTile, _nextSpawnPoint, Quaternion.identity);
        _nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            // pensar em forma melhor de fazer isso (após object pooling)
            temp.GetComponent<ObstacleSpawner>().SpawnObstacles();
            temp.GetComponent<CoinSpawner>().SpawnCoins();
        }
    }
}
