using System;
using UnityEngine;

public sealed class CoinObtained : MonoBehaviour
{
    //transformar em um delegate ou evento generico e fazer diferentes para os powerups
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

        gameObject.SetActive(false);
    }
}
