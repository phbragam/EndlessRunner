using UnityEngine;

public sealed class PlayerIncreaseSpeed : MonoBehaviour
{
    // criar scriptable object da speed;
    [SerializeField] private FloatValue _speedData;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float SpeedIncreasePerPoint;

    //private void Awake()
    //{
    //    _playerMovement = GetComponent<PlayerMovement>();
    //}

    private void OnEnable()
    {
        CoinObtained.OnCoinObtainedByPlayer += IncreaseSpeed;
    }

    private void OnDisable()
    {
        CoinObtained.OnCoinObtainedByPlayer -= IncreaseSpeed;
    }

    private void IncreaseSpeed()
    {
        if (_speedData.floatValue <= _maxSpeed)
        {
            _speedData.floatValue += SpeedIncreasePerPoint;
        }
        else
        {
            CoinObtained.OnCoinObtainedByPlayer -= IncreaseSpeed;
        }
    }
}
