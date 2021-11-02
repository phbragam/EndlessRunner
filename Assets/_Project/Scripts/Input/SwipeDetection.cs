using UnityEngine;

public sealed class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float _minimumDistance = .4f;
    [SerializeField] private float _maximumTime = 1f;
    [SerializeField, Range(0f, 1f)] private float _directionThreshold = .9f;

    private InputManager _inputManager;
    private PlayerMovement _playerMovement;
    private PlayerJump _playerJump;

    private Vector2 _startPosition;
    private float _startTime;
    private Vector2 _endPosition;
    private float _endTime;

    public void Initialize()
    {
        _inputManager = InputManager.Instance;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJump = GetComponent<PlayerJump>();
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
        _startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector2.Distance(_startPosition, _endPosition) >= _minimumDistance
            && (_endTime - _startTime) <= _maximumTime)
        {
            Vector2 direction = (_endPosition - _startPosition).normalized;
            SwipeDirection(direction);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
        {
            _playerJump.Jump();
        }
        else if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
        {
            _playerMovement.MoveLeft();
        }
        else if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
        {
            _playerMovement.MoveRight();
        }
    }
}
