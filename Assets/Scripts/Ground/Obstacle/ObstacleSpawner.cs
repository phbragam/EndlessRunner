using UnityEngine;

public sealed class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject _tallObstaclePrefab;

    // entre 0 e 1
    [SerializeField] private float _tallObstacleChance;

    // mudar para 3 variáveis distintas
    [SerializeField] private Transform _obstacleSpawnTransformLeft;
    [SerializeField] private Transform _obstacleSpawnTransformCenter;
    [SerializeField] private Transform _obstacleSpawnTransformRight;
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
        Vector3 spawnPoint = new Vector3();

        switch (obstacleSpawnIndex)
        {
            case (0):
                spawnPoint = _obstacleSpawnTransformLeft.position;
                break;
            case (1):
                spawnPoint = _obstacleSpawnTransformCenter.position;
                break;
            case (2):
                spawnPoint = _obstacleSpawnTransformRight.position;
                break;
            default:
                spawnPoint = _obstacleSpawnTransformCenter.position;
                break;
        }

        Instantiate(obstacleToSpawn, spawnPoint, Quaternion.identity, transform);
    }
}
