using UnityEngine;

public sealed class GroundTile : MonoBehaviour
{
    [SerializeField] private float _timeToReturnToPool;

    private GroundSpawner _groundSpawner;
    private GenericObjectPool _groundTilePool;

    // Start is called before the first frame update
    void Awake()
    {
        _groundSpawner = FindObjectOfType<GroundSpawner>();
        _groundTilePool = FindObjectOfType<GroundTilePoolReference>().GetComponent<GenericObjectPool>();
    }

    private void OnTriggerExit(Collider other)
    {
        _groundSpawner.SpawnTile(true);
        // adicionar object pooling
        //Destroy(gameObject, 2f);
        Invoke("BackToPool", _timeToReturnToPool);
    }

    private void BackToPool()
    {
        _groundTilePool.ReturnObjectToPool(gameObject);
    }
}
