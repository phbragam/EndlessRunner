using System.Collections;
using UnityEngine;

public sealed class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _baseJumpForce;
    [SerializeField] private float _maxJumpForce;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody _rb;

    private Animator _anim;

    public void Initialize()
    {
        InitializeRigidBody();
        InitializeAnimator();
    }

    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, (height / 2) + .1f, _groundMask);

        _anim.SetBool("Grounded", isGrounded);

        if (isGrounded)
        {
            _anim.SetTrigger("Jump");
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

    }

    public void IncreaseJumpForce(float jumpIncrease, float time)
    {

        if (_jumpForce < _maxJumpForce)
        {
            _jumpForce += jumpIncrease;
            StartCoroutine(NormalJumpForce(jumpIncrease, time));
        }

    }

    public IEnumerator NormalJumpForce(float jumpIncreased, float time)
    {
        yield return new WaitForSeconds(time);
        _jumpForce -= jumpIncreased;
    }

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        _jumpForce = _baseJumpForce;
    }

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += SetDeathAnimation;
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= SetDeathAnimation;
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
