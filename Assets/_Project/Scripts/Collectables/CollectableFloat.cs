using UnityEngine;

public class CollectableFloat : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _speed;

    private float _y0;

    private void Start()
    {
        _y0 = transform.position.y;
    }

    void Update()
    {

        float x = transform.position.x;
        float y = _y0 + _amplitude * Mathf.Sin(_speed * Time.time);
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
