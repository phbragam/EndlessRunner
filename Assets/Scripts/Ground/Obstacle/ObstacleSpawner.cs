using UnityEngine;

public sealed class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject _tallObstaclePrefab;

    // entre 0 e 1
    [SerializeField] private float _tallObstacleChance;

    // mudar para 3 variáveis distintas
    [SerializeField] private Transform[] _obstacleSpawnTransformArray = new Transform[3];

    // adicionar object pooling
    public void SpawnObstacles()
    {
        GameObject obstacleToSpawn = _obstaclePrefab;
        float random = Random.Range(0f, 1f);

        if (random < _tallObstacleChance)
        {
            obstacleToSpawn = _tallObstaclePrefab;
        }

        int obstacleSpawnIndex = Random.Range(0, 3);
        Transform spawnPoint = _obstacleSpawnTransformArray[obstacleSpawnIndex];

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
