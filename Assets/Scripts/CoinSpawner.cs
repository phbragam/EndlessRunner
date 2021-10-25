using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    private const float leftX = -3.3f; 
    private const float centerX = 0f; 
    private const float rightX = 3.3f; 

    // Start is called before the first frame update
    void Start()
    {
        //SpawnCoins();
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = Random.Range(0, 5);
        //int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            int lane = Random.Range(0, 3);
            Debug.Log(lane);
            switch (lane)
            {
                case (0):
                    temp.transform.position = new Vector3(leftX, temp.transform.position.y, temp.transform.position.z);
                    Debug.Log("entrou");
                    Debug.Log(transform.position);
                    break;
                case (1):
                    temp.transform.position = new Vector3(centerX, temp.transform.position.y, temp.transform.position.z);
                    Debug.Log("entrou");
                    Debug.Log(transform.position);
                    break;
                case (2):
                    temp.transform.position = new Vector3(rightX, temp.transform.position.y, temp.transform.position.z);
                    Debug.Log("entrou");
                    Debug.Log(transform.position);
                    break;
            }
        }

    }

    Vector3 GetRandomPointInCollider(Collider collider)
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
