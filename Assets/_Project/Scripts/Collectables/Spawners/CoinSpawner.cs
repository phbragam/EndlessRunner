using System.Collections.Generic;
using UnityEngine;

public sealed class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _slowSpeedPowerUpPrefab;
    [SerializeField] private GameObject _increaseJumpPowerUpPrefab;
    [SerializeField] private int _totalCoinsPerTile;
    [SerializeField] private int _slowSpeedInstantiateChance;
    [SerializeField] private int _increaseJumpInstantiateChance;

    private const float LeftLanePositionX = -3.3f;
    private const float CenterLanePositionX = 0f;
    private const float RightLanePositionX = 3.3f;

    private List<GameObject> _coinList = new List<GameObject>();

    public void Initialize()
    {
        InstantiateCoins();
        PlaceCoins();
    }

    public void PlaceCoins()
    {
        int coinsToActivate = Random.Range(0, _totalCoinsPerTile);
        ShuffleList(_coinList);

        for (int i = 0; i < _coinList.Count; i++)
        {

            if (i <= coinsToActivate)
            {
                //int randomCoinIndex = Random.Range(0, _coinList.Count);
                _coinList[i].SetActive(true);

                int numberOfLanes = 3;
                int lane = Random.Range(0, numberOfLanes);

                switch (lane)
                {
                    case (0):
                        _coinList[i].transform.position = new Vector3(LeftLanePositionX, _coinList[i].transform.position.y, _coinList[i].transform.position.z);
                        break;
                    case (1):
                        _coinList[i].transform.position = new Vector3(CenterLanePositionX, _coinList[i].transform.position.y, _coinList[i].transform.position.z);
                        break;
                    case (2):
                        _coinList[i].transform.position = new Vector3(RightLanePositionX, _coinList[i].transform.position.y, _coinList[i].transform.position.z);
                        break;
                }

            }

        }
    }

    public void DeactivateAllCoinsInTile()
    {

        foreach (GameObject coin in _coinList)
        {
            coin.SetActive(false);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void InstantiateCoins()
    {
        for (int i = 0; i < _totalCoinsPerTile; i++)
        {
            InstantiateCollectable(_coinPrefab);
        }

        int chanceSlow = Random.Range(0, 100);
        int chanceJump = Random.Range(0, 100);

        if (chanceSlow < _slowSpeedInstantiateChance)
        {
            InstantiateCollectable(_increaseJumpPowerUpPrefab);
        }

        if (chanceJump < _increaseJumpInstantiateChance)
        {
            InstantiateCollectable(_slowSpeedPowerUpPrefab);
        }
    }

    private void InstantiateCollectable(GameObject collectablePrefab)
    {
        GameObject temp = Instantiate(collectablePrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        temp.SetActive(false);
        _coinList.Add(temp);
    }

    private void InstantiateAndPlaceCoins()
    {

    }

    private void ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
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
