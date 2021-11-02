using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlowSpeed : MonoBehaviour
{
    [SerializeField] private float _speedDecrease;
    [SerializeField] private float _buffTime;

    private PlayerMovement _playerMovement;

    public void Initialize()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        SpeedSlowObtained.OnSpeedSlowObtainedByPlayer += SlowSpeed;
    }

    private void OnDisable()
    {
        SpeedSlowObtained.OnSpeedSlowObtainedByPlayer -= SlowSpeed;
    }

    private void SlowSpeed()
    {
        _playerMovement.SlowSpeed(_speedDecrease, _buffTime);
    }
}
