using System.Collections.Generic;
using UnityEngine;

public sealed class GenericObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Queue<GameObject> _objectPool = new Queue<GameObject>();
    [SerializeField] private int _poolInitialSize;

    private void Awake()
    {

        for (int i = 0; i < _poolInitialSize; i++)
        {
            GameObject obj = Instantiate(_objectPrefab);
            _objectPool.Enqueue(obj);
            obj.SetActive(false);

        }

    }

    public GameObject GetObjectInPool()
    {

        if (_objectPool.Count > 0)
        {
            //Debug.Log(_objectPool.Count);
            GameObject obj = _objectPool.Dequeue();
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
        _objectPool.Enqueue(obj);
        obj.SetActive(false);
    }

}
