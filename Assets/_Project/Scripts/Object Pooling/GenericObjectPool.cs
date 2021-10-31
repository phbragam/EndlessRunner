using System.Collections.Generic;
using UnityEngine;

public sealed class GenericObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Queue<GameObject> _objectPool = new Queue<GameObject>();
    [SerializeField] private int _poolInitialSize;

    public static GenericObjectPool Instance;

    public void Initialize()
    {
        Awake();
    }

    public GameObject GetObjectInPool()
    {

        if (_objectPool.Count > 0)
        {
            GameObject obj = Instance._objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(_objectPrefab);
            return obj;
        }

    }

    public void ReturnObjectToPool(GameObject obj)
    {
        Instance._objectPool.Enqueue(obj);
        obj.SetActive(false);
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Instance.InstatiatePoolElements();
    }

    private void InstatiatePoolElements()
    {
        for (int i = 0; i < _poolInitialSize; i++)
        {
            GameObject obj = Instantiate(_objectPrefab);
            Instance._objectPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
