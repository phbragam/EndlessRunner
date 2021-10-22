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
        //prototypePlayerInputActions.UI.Enable();

        prototypePlayerInputActions.Player.Jump.performed += Jump;
        prototypePlayerInputActions.UI.Submit.performed += Submit;
        //prototypePlayerInputActions.Player.Movement.performed += Movement_Performed;

        //rebinding
        //prototypePlayerInputActions.Player.Disable();
        //prototypePlayerInputActions.Player.Jump.PerformInteractiveRebinding()
        //    .WithControlsExcluding("Mouse")
        //    .OnComplete(callback =>
        //    {
        //        Debug.Log(callback.action.bindings[0].overridePath);
        //        // prevents memory leak
        //        callback.Dispose();
        //        prototypePlayerInputActions.Player.Enable();
        //    })
        //    .Start();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("clicked");
        }

        if (Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            Debug.Log("clicked north gamepad button");
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            //when using Player Input component
            //playerInput.SwitchCurrentActionMap("UI");
            prototypePlayerInputActions.Player.Disable();
            prototypePlayerInputActions.UI.Enable();
            Debug.Log("Changed to UI");
        }

        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            //when using Player Input component
            //playerInput.SwitchCurrentActionMap("Player");
            prototypePlayerInputActions.Player.Enable();
            prototypePlayerInputActions.UI.Disable();
            Debug.Log("Changed to Player");
        }

    }



    private void FixedUpdate()
    {
        Vector2 inputVector = prototypePlayerInputActions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(inputVector);
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
        //Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump! " + context.phase);
            sphereRigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    public void Submit(InputAction.CallbackContext context)
    {
        Debug.Log("Submit " + context);
    }
}
