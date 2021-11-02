using UnityEngine;

public sealed class PlayerIncreaseSpeed : MonoBehaviour
{
    [SerializeField] private float _speedIncreasePerPoint;
    [SerializeField] private float _baseSpeedIncreasePerPoint;

    private PlayerMovement _playerMovement;

    public void Initialize()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _speedIncreasePerPoint = _baseSpeedIncreasePerPoint;
    }

    private void Awake()
    {
        Initialize();
    }

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
        bool increased = _playerMovement.IncreaseSpeed(_speedIncreasePerPoint);

        if (!increased)
        {
            _speedIncreasePerPoint = 0f;
            //CoinObtained.OnCoinObtainedByPlayer -= IncreaseSpeed;
        }
        else
        {
            _speedIncreasePerPoint = _baseSpeedIncreasePerPoint;
        }
    }
}
