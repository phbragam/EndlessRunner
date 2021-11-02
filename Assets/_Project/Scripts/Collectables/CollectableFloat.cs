using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFloat : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float speed;

    private float y0;

    // Start is called before the first frame update
    void Start()
    {
        y0 = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        float x = transform.position.x;
        float y = y0 + amplitude * Mathf.Sin(speed * Time.time);
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
