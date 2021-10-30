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
            _groundSpawner.SpawnTile();
            // adicionar object pooling
            //Destroy(gameObject, 2f);
            Invoke("BackToPool", _timeToReturnToPool);
            // desativar os obstaculos 
            Invoke("RelocateObstacle", _timeToReturnToPool);
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
}
