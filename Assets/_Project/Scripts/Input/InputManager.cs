using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public sealed class InputManager : MonoBehaviour
{
    public event Action<Vector2, float> OnStartTouch;
    public event Action<Vector2, float> OnEndTouch;
    //public delegate void StartTouch(Vector2 position, float time);
    // precisa do event?
    //public event StartTouch OnStartTouch;
    //public delegate void EndTouch(Vector2 position, float time);
    //public event EndTouch OnEndTouch;

    public static InputManager Instance;
    private TouchControls _touchControls;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        _touchControls.Enable();
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
        TouchSimulation.Disable();
    }

    void Start()
    {
        _touchControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        _touchControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(_touchControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(_touchControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);
    }




}
