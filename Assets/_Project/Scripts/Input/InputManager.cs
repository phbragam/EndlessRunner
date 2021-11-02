using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public sealed class InputManager : MonoBehaviour
{
    public event Action<Vector2, float> OnStartTouch;
    public event Action<Vector2, float> OnEndTouch;

    public static InputManager Instance;
    private TouchControls _touchControls;

    public void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _touchControls = new TouchControls();
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DisableTouch;
        _touchControls.Enable();
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= DisableTouch;
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

    private void DisableTouch()
    {
        _touchControls.Disable();
        TouchSimulation.Disable();
    }


}
