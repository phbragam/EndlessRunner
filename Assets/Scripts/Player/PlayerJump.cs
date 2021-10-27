using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//mudar para PlayerJump
public class PlayerJump : MonoBehaviour
{
    public PrototypePlayerInputActions prototypePlayerInputActions;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] LayerMask groundMask;

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DisableJump;
    }

    private void OnDisable()
    {
        prototypePlayerInputActions.Player.Disable();
        PlayerDieScript.OnPlayerDied -= DisableJump;
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        prototypePlayerInputActions = new PrototypePlayerInputActions();
        prototypePlayerInputActions.Player.Enable();
        prototypePlayerInputActions.Player.Jump.started += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {

        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        Debug.Log(context);
        Debug.Log("Pulou");
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void DisableJump()
    {
        GetComponent<PlayerJump>().enabled = false;
    }
}
