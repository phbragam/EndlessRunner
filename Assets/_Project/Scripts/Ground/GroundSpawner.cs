using UnityEngine;

public sealed class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _groudTile;

    private GenericObjectPool _groundTilePool;
    private Vector3 _nextSpawnPoint;

    private void Awake()
    {
        _groundTilePool = FindObjectOfType<GroundTilePoolReference>().GetComponent<GenericObjectPool>();
    }

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
        GameObject groundTile = _groundTilePool.GetObjectInPool();
        groundTile.transform.position = _nextSpawnPoint;
        groundTile.transform.rotation = Quaternion.identity;
        //GameObject temp = Instantiate(_groudTile, _nextSpawnPoint, Quaternion.identity);
        _nextSpawnPoint = groundTile.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            // pensar em forma melhor de fazer isso (após object pooling)
            //temp.GetComponent<ObstacleSpawner>().SpawnObstacles();
            //temp.GetComponent<CoinSpawner>().SpawnCoins();
        }
    }
}
