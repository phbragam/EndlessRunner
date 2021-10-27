using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerJump : MonoBehaviour
{
    [SerializeField] private FloatValue _jumpForceData;
    [SerializeField] private LayerMask _groundMask;

    private PrototypePlayerInputActions _prototypePlayerInputActions;
    private Rigidbody _rb;

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DisableJump;
        PlayerDieScript.OnPlayerDied += ResetJumpForce;
    }

    private void OnDisable()
    {
        _prototypePlayerInputActions.Player.Disable();
        PlayerDieScript.OnPlayerDied -= DisableJump;
        PlayerDieScript.OnPlayerDied -= ResetJumpForce;
    }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _prototypePlayerInputActions = new PrototypePlayerInputActions();
        _prototypePlayerInputActions.Player.Enable();
        _prototypePlayerInputActions.Player.Jump.started += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {

        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, _groundMask);

        if (isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForceData.floatValue, ForceMode.Impulse);
        }

    }

    private void DisableJump()
    {
        GetComponent<PlayerJump>().enabled = false;
    }

    private void ResetJumpForce()
    {
        _jumpForceData.floatValue = _jumpForceData.defaultFloatValue;
    }
}
