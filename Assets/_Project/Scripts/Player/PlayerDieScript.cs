using System;
using UnityEngine;

public sealed class PlayerDieScript : MonoBehaviour
{
    public static event Action OnPlayerDied;

    private void Update()
    {
        InvokeDeathEventOnFall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        InvokeDeathEventOnCollision(collision);
    }

    private void InvokeDeathEventOnFall()
    {

        if (transform.position.y <= -5)
        {
            OnPlayerDied?.Invoke();
        }

    }

    private void InvokeDeathEventOnCollision(Collision collision)
    {

        if (collision.gameObject.GetComponent<ObstacleReference>())
        {
            OnPlayerDied?.Invoke();
        }

    }
}
