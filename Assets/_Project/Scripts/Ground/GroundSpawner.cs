using UnityEngine;

public sealed class GroundSpawner : MonoBehaviour
{
    [SerializeField] private int _initialNumberOfTiles;

    private GenericObjectPool _groundTilePool;
    private Vector3 _nextSpawnPoint;

    private void Awake()
    {
        _groundTilePool = FindObjectOfType<GroundTilePoolReference>().GetComponent<GenericObjectPool>();
    }

    private void Start()
    {

        for (int i = 0; i < _initialNumberOfTiles; i++)
        {
            RelocateTile(i);
        }
    }

    public void RelocateTile(int number)
    {
        GameObject groundTile = _groundTilePool.GetObjectInPool();
        groundTile.transform.position = _nextSpawnPoint;
        groundTile.transform.rotation = Quaternion.identity;
        _nextSpawnPoint = groundTile.transform.GetChild(1).transform.position;

        groundTile.GetComponent<GroundTile>().Number = number;
    }

    public void RelocateTile()
    {
        GameObject groundTile = _groundTilePool.GetObjectInPool();
        groundTile.transform.position = _nextSpawnPoint;
        groundTile.transform.rotation = Quaternion.identity;
        _nextSpawnPoint = groundTile.transform.GetChild(1).transform.position;

        groundTile.GetComponent<GroundTile>().Number = 99;
    }
}
