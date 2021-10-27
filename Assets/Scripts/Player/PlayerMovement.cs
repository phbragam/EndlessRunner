using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerMovement : MonoBehaviour
{
    public enum Lane { Left, Center, Right }

    [SerializeField] private float _laneDistance = 3.3f;
    [SerializeField] private FloatValue _speedData;

    private PlayerMovement _playerMovement;
    private Lane TargetLane;

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
        _playerMovement = this;
        TargetLane = Lane.Center;
    }

    private void Update()
    {

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            MoveLane(false);
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            MoveLane(true);
        }

    }

    private void FixedUpdate()
    {
        Vector3 targetPos = SwitchTargetPosition();
        Move(targetPos);
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
            // moveVector.x pode ser 0, 1 ou -1
            moveVector.x = (targetPos - transform.position).normalized.x * _speedData.floatValue;
            moveVector.z = _speedData.floatValue;
            transform.Translate(moveVector * Time.fixedDeltaTime);
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
