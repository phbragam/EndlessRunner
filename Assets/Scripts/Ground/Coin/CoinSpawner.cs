using UnityEngine;

public sealed class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    private const float LeftLanePositionX = -3.3f; 
    private const float CenterLanePositionX = 0f; 
    private const float RightLanePositionX = 3.3f; 

    // adicionar object pooling
    public void SpawnCoins()
    {
        int coinsToSpawn = Random.Range(0, 5);
        //int coinsToSpawn = 10;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(_coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            int lane = Random.Range(0, 3);

            switch (lane)
            {
                case (0):
                    temp.transform.position = new Vector3(LeftLanePositionX, temp.transform.position.y, temp.transform.position.z);
                    //Debug.Log(transform.position);
                    break;
                case (1):
                    temp.transform.position = new Vector3(CenterLanePositionX, temp.transform.position.y, temp.transform.position.z);
                    //Debug.Log(transform.position);
                    break;
                case (2):
                    temp.transform.position = new Vector3(RightLanePositionX, temp.transform.position.y, temp.transform.position.z);
                    //Debug.Log(transform.position);
                    break;
            }

        }
    }

    private Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            1,
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        return point;
    }
}
