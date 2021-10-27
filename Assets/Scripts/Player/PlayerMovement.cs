using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private float laneDistance = 3.3f;
    public enum Lane { Left, Center, Right }
    Lane targetLane;

    PlayerMovement playerMovement;

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DisableMovement;
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= DisableMovement;
    }

    private void Awake()
    {
        playerMovement = this;
        targetLane = Lane.Center;
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
            switch (targetLane)
            {
                case (Lane.Right):
                    targetLane = Lane.Center;
                    break;
                case (Lane.Center):
                    targetLane = Lane.Left;
                    break;
            }
        }
        else
        {
            switch (targetLane)
            {
                case (Lane.Left):
                    targetLane = Lane.Center;
                    break;
                case (Lane.Center):
                    targetLane = Lane.Right;
                    break;
            }
        }
    }

    private Vector3 SwitchTargetPosition()
    {
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        switch (targetLane)
        {
            case (Lane.Right):
                targetPosition += Vector3.right * laneDistance;
                break;
            case (Lane.Center):
                break;
            case (Lane.Left):
                targetPosition += Vector3.left * laneDistance;
                break;
        }

        return targetPosition;
    }

    private void Move(Vector3 targetPos)
    {
            Vector3 moveVector = Vector3.zero;
            // moveVector.x pode ser 0, 1 ou -1
            moveVector.x = (targetPos - transform.position).normalized.x * speed;
            moveVector.z = speed;
            transform.Translate(moveVector * Time.fixedDeltaTime);
    }

    void DisableMovement()
    {
        playerMovement.enabled = false;
    }
}
