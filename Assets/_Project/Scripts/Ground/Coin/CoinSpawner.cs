using System.Collections.Generic;
using UnityEngine;

public sealed class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _totalCoinsPerTile;

    private const float LeftLanePositionX = -3.3f;
    private const float CenterLanePositionX = 0f;
    private const float RightLanePositionX = 3.3f;

    private List<GameObject> _coinList = new List<GameObject>();

    private void Awake()
    {
        InstantiateCoins();
        PlaceCoins();
    }

    private void InstantiateCoins()
    {
        for (int i = 0; i < _totalCoinsPerTile; i++)
        {
            GameObject temp = Instantiate(_coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            temp.SetActive(false);
            _coinList.Add(temp);
        }
    }

    // adicionar object pooling
    public void PlaceCoins()
    {
        int coinsToActivate = Random.Range(0, _totalCoinsPerTile);
        //int coinsToSpawn = 10;

        for (int i = 0; i < _coinList.Count; i++)
        {

            if (i <= coinsToActivate)
            {
                _coinList[i].SetActive(true);

                int numberOfLanes = 3;
                int lane = Random.Range(0, numberOfLanes);

                switch (lane)
                {
                    case (0):
                        _coinList[i].transform.position = new Vector3(LeftLanePositionX, _coinList[i].transform.position.y, _coinList[i].transform.position.z);
                        //Debug.Log(transform.position);
                        break;
                    case (1):
                        _coinList[i].transform.position = new Vector3(CenterLanePositionX, _coinList[i].transform.position.y, _coinList[i].transform.position.z);
                        //Debug.Log(transform.position);
                        break;
                    case (2):
                        _coinList[i].transform.position = new Vector3(RightLanePositionX, _coinList[i].transform.position.y, _coinList[i].transform.position.z);
                        //Debug.Log(transform.position);
                        break;
                }
            }
            //GameObject temp = Instantiate(_coinPrefab, transform);
            //temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
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

    public void DeactivateAllCoinsInTile()
    {

        foreach (GameObject coin in _coinList)
        {
            coin.SetActive(false);
        }
    }
}
