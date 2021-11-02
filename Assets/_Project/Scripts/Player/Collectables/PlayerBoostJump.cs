using UnityEngine;

public class PlayerBoostJump : MonoBehaviour
{
    //[SerializeField] private float _speedIncreasePerPoint;
    [SerializeField] private float _jumpIncrease;
    [SerializeField] private float _buffTime;

    private PlayerJump _playerJump;

    public void Initialize()
    {
        _playerJump = GetComponent<PlayerJump>();
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        JumpBoostObtained.OnJumpBoostObtainedByPlayer += IncreaseJump;
    }

    private void OnDisable()
    {
        JumpBoostObtained.OnJumpBoostObtainedByPlayer -= IncreaseJump;
    }

    private void IncreaseJump()
    {
        _playerJump.IncreaseJumpForce(_jumpIncrease, _buffTime);
    }
}
