using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public PrototypePlayerInputActions prototypePlayerInputActions;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sideForce;
    [SerializeField] LayerMask groundMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        prototypePlayerInputActions = new PrototypePlayerInputActions();
        prototypePlayerInputActions.Player.Enable();

        prototypePlayerInputActions.Player.Jump.started += Jump;
        prototypePlayerInputActions.Player.MoveRight.started += Right;
        prototypePlayerInputActions.Player.MoveLeft.started += Left;
    }

    private void Right(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Debug.Log("Right");
        rb.AddForce(Vector3.right * sideForce, ForceMode.Impulse);
    }


    private void Left(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Debug.Log("Left");
        rb.AddForce(Vector3.right * -sideForce, ForceMode.Impulse);
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

    private void OnDisable()
    {
        prototypePlayerInputActions.Player.Disable();
    }






}
