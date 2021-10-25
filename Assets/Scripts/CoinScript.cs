using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinScript : MonoBehaviour
{
    [SerializeField] public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>())
        {
            Destroy(gameObject);
            return;
        }

        if (!other.gameObject.GetComponent<PlayerReference>())
        {
            return;
        }

        GameManager.inst.IncrementScore();

        Destroy(gameObject);
    }

    private void Awake()
    {

    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }


}
