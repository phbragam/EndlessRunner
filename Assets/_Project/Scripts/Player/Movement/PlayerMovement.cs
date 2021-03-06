using System.Collections;
using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _laneDistance = 3.3f;
    [SerializeField] private float _speed;
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private PlayerMovement _playerMovement;
    private Lane TargetLane;

    public void Initialize()
    {
        _playerMovement = this;
        TargetLane = Lane.Center;
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

    public void SlowSpeed(float speedDecrease, float time)
    {

        if (_speed - speedDecrease > _minSpeed)
        {
            _speed -= speedDecrease;
            StartCoroutine(NormalSpeed(speedDecrease, time));
        }

    }

    public IEnumerator NormalSpeed(float speedDecreased, float time)
    {
        yield return new WaitForSeconds(time);
        _speed += speedDecreased;
    }

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        _speed = _baseSpeed;
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

    public void MoveLeft()
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

    public void MoveRight()
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
        _playerMovement.enabled = false;
    }
}
