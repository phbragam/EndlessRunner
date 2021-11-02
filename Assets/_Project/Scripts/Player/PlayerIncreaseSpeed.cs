using UnityEngine;

public sealed class PlayerIncreaseSpeed : MonoBehaviour
{
    [SerializeField] private float _speedIncreasePerPoint;

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
            CoinObtained.OnCoinObtainedByPlayer -= IncreaseSpeed;
        }
    }
}
