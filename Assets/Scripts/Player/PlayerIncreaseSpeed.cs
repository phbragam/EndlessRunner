using UnityEngine;

public sealed class PlayerIncreaseSpeed : MonoBehaviour
{
    // criar scriptable object da speed;
    [SerializeField] PlayerMovement _playerMovement;

    public float SpeedIncreasePerPoint = .1f;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
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
        _playerMovement.Speed += SpeedIncreasePerPoint;
    }
}
