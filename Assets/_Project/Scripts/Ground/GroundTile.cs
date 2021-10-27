using UnityEngine;

public sealed class GroundTile : MonoBehaviour
{
    private GroundSpawner _groundSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        _groundSpawner = FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        _groundSpawner.SpawnTile(true);
        // adicionar object pooling
        Destroy(gameObject, 2f);
    }
}
