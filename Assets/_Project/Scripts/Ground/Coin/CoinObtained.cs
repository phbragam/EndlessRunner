using System;
using UnityEngine;

public sealed class CoinObtained : MonoBehaviour
{
    public static event Action OnCoinObtainedByPlayer;

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<ObstacleReference>())
        {
            gameObject.SetActive(false);
            return;
        }

        if (!other.gameObject.GetComponent<PlayerReference>())
        {
            return;
        }

        OnCoinObtainedByPlayer?.Invoke();

        // object pooling
        gameObject.SetActive(false);
    }
}
