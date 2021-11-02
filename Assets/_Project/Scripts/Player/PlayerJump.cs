using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody _rb;

    private Animator _anim;

    public void Initialize()
    {
        InitializeRigidBody();
        InitializeAnimator();
    }

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += SetDeathAnimation;
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= SetDeathAnimation;
    }


    private void Awake()
    {
        Initialize();
    }

    public void Jump()
    {

        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, (height / 2) + .1f, _groundMask);

        _anim.SetBool("Grounded", isGrounded);

        if (isGrounded)
        {
            _anim.SetTrigger("Jump");
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void InitializeRigidBody()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void InitializeAnimator()
    {
        _anim = GetComponent<Animator>();
    }

    private void SetDeathAnimation()
    {
        _anim.SetTrigger("Dead");
    }


}
