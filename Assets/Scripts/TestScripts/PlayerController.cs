using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.Enable();

        playerInputActions.Player.Jump.performed += DoJump;
        playerInputActions.Player.Jump.Enable();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump!!");
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player.Jump.Disable();
    }

    private void FixedUpdate()
    {
        Debug.Log("Movement Values " + movement.ReadValue<Vector2>());
    }

}
