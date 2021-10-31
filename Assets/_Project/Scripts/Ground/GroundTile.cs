using UnityEngine;

public sealed class GroundTile : MonoBehaviour
{
    [SerializeField] private float _timeToReturnToPool;

    private GroundSpawner _groundSpawner;
    private ObstacleSpawner _obstacleSpawner;
    private CoinSpawner _coinSpawner;

    public int Number { get;  set; }

    public void Initialize()
    {
        Awake();
    }

    private void Awake()
    {
        FindSpawnersAndPool();
    }

    private void Start()
    {
        DeactivateFirstObstacles();
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<PlayerReference>())
        {
            BackToPoolAndSetUp();
        }

    }

    private void FindSpawnersAndPool()
    {
        _groundSpawner = FindObjectOfType<GroundSpawner>();

        _obstacleSpawner = GetComponent<ObstacleSpawner>();
        _coinSpawner = GetComponent<CoinSpawner>();
    }

    private void BackToPoolAndSetUp()
    {
        _groundSpawner.RelocateTile();
        Invoke("BackToPool", _timeToReturnToPool);
        Invoke("RelocateObstacle", _timeToReturnToPool);
        Invoke("RelocateCoins", _timeToReturnToPool);
        _coinSpawner.DeactivateAllCoinsInTile();
    }

    private void BackToPool()
    {
        GenericObjectPool.Instance.ReturnObjectToPool(gameObject);
    }

    private void RelocateObstacle()
    {
        GameObject relocatedObstacle = _obstacleSpawner.ChooseObstacle();
        _obstacleSpawner.PlaceObstacle(relocatedObstacle);
    }

    private void RelocateCoins()
    {
        _coinSpawner.PlaceCoins();
    }

    private void DeactivateFirstObstacles()
    {
        if (Number < 3)
        {
            _obstacleSpawner.DeactivateObstacles();
        }
    }
}
