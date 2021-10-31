using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _laneDistance = 3.3f;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    private PlayerMovement _playerMovement;
    private PlayerInputActions _playerInputActions;
    private Lane TargetLane;

    public void Initialize()
    {
        
    }

    public bool IncreaseSpeed(float speedIncreasePerPoint)
    {

        if (_speed < _maxSpeed)
        {
            _speed += speedIncreasePerPoint;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Awake()
    {
        SetUpMovement();
    }

    private void Update()
    {
        Vector3 targetPos = SwitchTargetPosition();
        Move(targetPos);
    }

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DisableMovement;
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= DisableMovement;
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        switch (TargetLane)
        {
            case (Lane.Right):
                TargetLane = Lane.Center;
                break;
            case (Lane.Center):
                TargetLane = Lane.Left;
                break;
        }
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        switch (TargetLane)
        {
            case (Lane.Left):
                TargetLane = Lane.Center;
                break;
            case (Lane.Center):
                TargetLane = Lane.Right;
                break;
        }
    }

    private Vector3 SwitchTargetPosition()
    {
        Vector3 targetPosition = transform.position.z * Vector3.forward;

        switch (TargetLane)
        {
            case (Lane.Right):
                targetPosition += Vector3.right * _laneDistance;
                break;
            case (Lane.Center):
                break;
            case (Lane.Left):
                targetPosition += Vector3.left * _laneDistance;
                break;
        }

        return targetPosition;
    }

    private void Move(Vector3 targetPos)
    {
        Vector3 moveVector = Vector3.zero;
        Vector3 difference = targetPos - transform.position;

        if (difference.x >= -0.2f && difference.x <= 0.2f)
        {
            difference.x = 0f;
        }

        if (difference.x >= _laneDistance - 0.2f && difference.x <= _laneDistance + 0.2f)
        {
            difference.x = _laneDistance;
        }

        if (difference.x >= (-_laneDistance - 0.2f) && difference.x <= (-_laneDistance + 0.2f))
        {
            difference.x = -_laneDistance;
        }

        moveVector.x = (difference).normalized.x * _speed;
        moveVector.z = _speed;
        transform.Translate(moveVector * Time.fixedDeltaTime);
    }


    private void DisableMovement()
    {
        _playerInputActions.Player.Left.Disable();
        _playerInputActions.Player.Right.Disable();
        _playerMovement.enabled = false;
    }

    private void SetUpMovement()
    {
        InitializePlayerInputActions();

        _playerMovement = this;
        TargetLane = Lane.Center;
    }

    private void InitializePlayerInputActions()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Left.Enable();
        _playerInputActions.Player.Right.Enable();
        _playerInputActions.Player.Left.performed += MoveLeft;
        _playerInputActions.Player.Right.performed += MoveRight;
    }
}
