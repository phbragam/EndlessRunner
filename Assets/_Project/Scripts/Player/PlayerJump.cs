using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask _groundMask;

    private PrototypePlayerInputActions _playerInputActions;
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
        //Debug.Log(height);
        // ajustar primeiro parametro do raycast
        bool isGrounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, (height / 2) + .1f, _groundMask);
        //Debug.Log(transform.position);
        //Debug.Log(transform.position + Vector3.down * ((height / 2) + .1f));

        Debug.DrawRay(transform.position, Vector3.down, Color.yellow, 10f);

        //Debug.Log(isGrounded);
        if (isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void Update()
    {
        //float height = GetComponent<Collider>().bounds.size.y;
        //bool isGrounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, (height / 2) + .1f, _groundMask);

        //if (isGrounded)
        //{
        //    //Debug.Log("Grounded");
        //}
        //else
        //{
        //    //Debug.Log("Not Grounded");
        //}
    }

    private void SetUpJump()
    {
        _rb = GetComponent<Rigidbody>();

        _playerInputActions = new PrototypePlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Jump.started += Jump;
    }

    private void DisableJump()
    {
        //??
        _playerInputActions.Player.Disable();
        GetComponent<PlayerJump>().enabled = false;
    }
}
