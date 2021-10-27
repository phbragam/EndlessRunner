using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerMovement : MonoBehaviour
{
    // criar script separado
    public enum Lane { Left, Center, Right }

    [SerializeField] private float _laneDistance = 3.3f;
    // mudar
    [SerializeField] private FloatValue _speedData;

    private PlayerMovement _playerMovement;
    private Lane TargetLane;
    //private int desiredLane = 1;

    public void Initialize()
    {
        _playerMovement = this;
        TargetLane = Lane.Center;
    }

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DisableMovement;
        PlayerDieScript.OnPlayerDied += ResetSpeed;
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= DisableMovement;
        PlayerDieScript.OnPlayerDied -= ResetSpeed;
    }

    private void Awake()
    {
        Initialize();
    }

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
        ClampPositionX();
    }

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
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
                break;
            case (Lane.Center):
                break;
            case (Lane.Left):
                targetPosition += Vector3.left * _laneDistance;
                break;
        }

        //Debug.Log(targetPosition);
        return targetPosition;
    }

    private void Move(Vector3 targetPos)
    {
        Vector3 moveVector = Vector3.zero;
        // moveVector.x pode ser 0, 1 ou -1
        moveVector.x = (targetPos - transform.position).normalized.x * _speedData.floatValue;
        moveVector.z = _speedData.floatValue;
        transform.Translate(moveVector * Time.deltaTime);
    }

    private void ClampPositionX()
    {
        Vector3 positionClamped = transform.position;
        positionClamped.x = Mathf.Clamp(transform.position.x, -_laneDistance, _laneDistance);

        if (transform.position.x >= -0.2f && transform.position.x <= 0.2f)
        {
            transform.position = new Vector3(0f, positionClamped.y, positionClamped.z);
        }
        else
        {
            transform.position = positionClamped;
        }

    }

    private void DisableMovement()
    {
        _playerMovement.enabled = false;
    }

    private void ResetSpeed()
    {
        _speedData.floatValue = _speedData.defaultFloatValue;
    }
}
