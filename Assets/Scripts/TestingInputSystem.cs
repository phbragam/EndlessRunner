using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody sphereRigidbody;
    private PlayerInput playerInput;

    private PrototypePlayerInputActions prototypePlayerInputActions;

    private void Awake()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        prototypePlayerInputActions = new PrototypePlayerInputActions();
        prototypePlayerInputActions.Player.Enable();
        prototypePlayerInputActions.Player.Jump.performed += Jump;
        //prototypePlayerInputActions.Player.Movement.performed += Movement_Performed;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = prototypePlayerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 5f;
        sphereRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    //private void Movement_Performed(InputAction.CallbackContext context)
    //{
    //    Debug.Log(context);
    //    Vector2 inputVector = context.ReadValue<Vector2>();
    //    float speed = 5f;
    //    sphereRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    //}

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump! " + context.phase);
            sphereRigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}
