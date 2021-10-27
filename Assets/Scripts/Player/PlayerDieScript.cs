using System;
using UnityEngine;

public sealed class PlayerDieScript : MonoBehaviour
{
    public static event Action OnPlayerDied;

    private void Update()
    {
        if (transform.position.y <= -5)
        {
            OnPlayerDied?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObstacleReference>())
        {
            OnPlayerDied?.Invoke();
        }
    }
}
