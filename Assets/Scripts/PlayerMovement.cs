using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    
    public float speed = 5f;
    public float speedIncreasePerPoint = .1f;

    private const float laneDistance = 3.3f;
    public enum Lane { Left, Center, Right }
    Lane targetLane;

    private void Awake()
    {
        targetLane = Lane.Center;
    }

    private void FixedUpdate()
    {
        if (!alive) return;

    }

    private void Update()
    {
        if (transform.position.y <= -5)
        {
            Die();
        }

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
        //Debug.Log(targetLane);
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
        if (alive)
        {
            Vector3 moveVector = Vector3.zero;
            moveVector.x = (targetPos - transform.position).normalized.x * speed;
            moveVector.y = transform.position.y;
            moveVector.z = speed;
            transform.Translate(moveVector * Time.deltaTime);
            //Debug.Log("move vector: " + moveVector);
        }
    }

    public void Die()
    {
        alive = false;

        Invoke("ReloadScene", 1f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
