using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _laneDistance = 3.3f;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    private PlayerMovement _playerMovement;
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

    // ajustar depois do almoço
    private void Update()
    {
        //Debug.Log(transform.position.x);
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            MoveLane(false);
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            MoveLane(true);
        }

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

    private void MoveLane(bool goingRight)
    {

        if (!goingRight)
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
        else
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

    }

    // fazer não ser chamado todos os frames
    private Vector3 SwitchTargetPosition()
    {
        Vector3 targetPosition = transform.position.z * Vector3.forward;

        switch (TargetLane)
        {
            case (Lane.Right):
                targetPosition += Vector3.right * _laneDistance;
                //Debug.Log(TargetLane + "" + targetPosition);
                break;
            case (Lane.Center):
                //Debug.Log(TargetLane + "" + targetPosition);
                break;
            case (Lane.Left):
                targetPosition += Vector3.left * _laneDistance;
                //Debug.Log(TargetLane + "" + targetPosition);
                break;
        }

        //Debug.Log(targetPosition);
        return targetPosition;
    }

    private void Move(Vector3 targetPos)
    {
        Vector3 moveVector = Vector3.zero;
        // moveVector.x pode ser 0, 1 ou -1

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
        _playerMovement.enabled = false;
    }

    private void SetUpMovement()
    {
        _playerMovement = this;
        TargetLane = Lane.Center;
    }
}
