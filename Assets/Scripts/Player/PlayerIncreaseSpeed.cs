using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIncreaseSpeed : MonoBehaviour
{
    // criar scriptable object da speed;
    public float speedIncreasePerPoint = .1f;
    [SerializeField] PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        CoinObtained.OnCoinObtainedByPlayer += IncreaseSpeed;
    }

    private void OnDisable()
    {
        CoinObtained.OnCoinObtainedByPlayer -= IncreaseSpeed;
    }

    void IncreaseSpeed()
    {
        playerMovement.speed += speedIncreasePerPoint;
    }
}
