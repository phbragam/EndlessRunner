using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask _groundMask;

    private PlayerInputActions _playerInputActions;
    private Rigidbody _rb;

    public void Initialize()
    {

    }

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DisableJump;
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= DisableJump;
    }


    private void Awake()
    {
        SetUpJump();
    }

    private void Jump(InputAction.CallbackContext context)
    {

        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, (height / 2) + .1f, _groundMask);

        if (isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void SetUpJump()
    {
        _rb = GetComponent<Rigidbody>();

        InitializePlayerInputActions();
    }

    private void InitializePlayerInputActions()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Jump.Enable();
        _playerInputActions.Player.Jump.started += Jump;
    }

    private void DisableJump()
    {
        _playerInputActions.Player.Jump.Disable();
    }
}
