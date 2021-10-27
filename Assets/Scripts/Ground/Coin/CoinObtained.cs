using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinObtained : MonoBehaviour
{
    public static event Action OnCoinObtainedByPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObstacleReference>())
        {
            Destroy(gameObject);
            return;
        }

        if (!other.gameObject.GetComponent<PlayerReference>())
        {
            return;
        }

        OnCoinObtainedByPlayer?.Invoke();
        Destroy(gameObject);
    }
}
