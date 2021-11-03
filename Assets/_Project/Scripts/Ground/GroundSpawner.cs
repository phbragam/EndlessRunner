using UnityEngine;

public sealed class GroundSpawner : MonoBehaviour
{
    [SerializeField] private int _initialNumberOfTiles;

    private Vector3 _nextSpawnPoint;

    public void RelocateTile()
    {
        GameObject groundTile = GenericObjectPool.Instance.GetObjectInPool();
        groundTile.transform.position = _nextSpawnPoint;
        groundTile.transform.rotation = Quaternion.identity;
        _nextSpawnPoint = groundTile.transform.GetChild(1).transform.position;

        groundTile.GetComponent<GroundTile>().Number = 99;
    }

    private void Start()
    {
        InitialPooling();
    }

    private void InitialPooling()
    {

        for (int i = 0; i < _initialNumberOfTiles; i++)
        {
            RelocateTile(i);
        }

    }

    private void RelocateTile(int number)
    {
        GameObject groundTile = GenericObjectPool.Instance.GetObjectInPool();
        groundTile.transform.position = _nextSpawnPoint;
        groundTile.transform.rotation = Quaternion.identity;
        _nextSpawnPoint = groundTile.transform.GetChild(1).transform.position;

        groundTile.GetComponent<GroundTile>().Number = number;
    }
}
