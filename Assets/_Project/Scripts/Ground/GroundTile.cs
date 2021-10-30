using UnityEngine;

public sealed class GroundTile : MonoBehaviour
{
    [SerializeField] private float _timeToReturnToPool;

    private GroundSpawner _groundSpawner;
    private GenericObjectPool _groundTilePool;
    private ObstacleSpawner _obstacleSpawner;
    private CoinSpawner _coinSpawner;

    public int Number { get;  set; }
    // Start is called before the first frame update
    void Awake()
    {
        _groundSpawner = FindObjectOfType<GroundSpawner>();
        _groundTilePool = FindObjectOfType<GroundTilePoolReference>().GetComponent<GenericObjectPool>();

        _obstacleSpawner = GetComponent<ObstacleSpawner>();
        _coinSpawner = GetComponent<CoinSpawner>();

        
    }

    private void Start()
    {

        if (Number < 3)
        {
            _obstacleSpawner.DeactivateObstacles();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<PlayerReference>())
        {
            _groundSpawner.RelocateTile();
            Invoke("BackToPool", _timeToReturnToPool);
            Invoke("RelocateObstacle", _timeToReturnToPool);
            Invoke("RelocateCoins", _timeToReturnToPool);
            _coinSpawner.DeactivateAllCoinsInTile();

        }
    }

    private void BackToPool()
    {
        _groundTilePool.ReturnObjectToPool(gameObject);
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
}
