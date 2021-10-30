using UnityEngine;

public sealed class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _tallObstacleChance;

    [SerializeField] private Transform _obstacleSpawnTransformLeft;
    [SerializeField] private Transform _obstacleSpawnTransformCenter;
    [SerializeField] private Transform _obstacleSpawnTransformRight;

    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameObject _tallObstacle;

    private void Awake()
    {
        GameObject obstacle = ChooseObstacle();
        PlaceObstacle(obstacle);
    }

    public GameObject ChooseObstacle()
    {
        float random = Random.Range(0f, 1f);

        if (random < _tallObstacleChance)
        {
            _obstacle.SetActive(false);
            _tallObstacle.SetActive(true);

            return _tallObstacle;
        }
        else
        {
            _obstacle.SetActive(true);
            _tallObstacle.SetActive(false);

            return _obstacle;
        }

    }

    public void PlaceObstacle(GameObject obstacle)
    {
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

        obstacle.transform.position = spawnPoint;
    }

    public void DeactivateObstacles()
    {
        _obstacle.SetActive(false);
        _tallObstacle.SetActive(false);
    }
}
