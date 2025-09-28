using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public bool IsAttacking { get; private set; }
    public bool IsBlocking { get; private set; }
    public Vector2 MovementValue { get; private set; }

    public event Action JumpEvent;
    public event Action DodgeEvent;
    public event Action TargetEvent;
    public event Action ELightEvent;

    private Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        if (controls != null)
        {
            controls.Player.Disable();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {

    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        TargetEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsAttacking = true;
        }
        else if (context.canceled)
        {
            IsAttacking = false;
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsBlocking = true;
        }
        else if (context.canceled)
        {
            IsBlocking = false;
        }
    }

    [Header("UI References")]
    [SerializeField] private Canvas menuCanvas;

    public void OnEsc(InputAction.CallbackContext context)
    {
        Debug.Log($"OnEsc called! Context: {context.phase}");
        
        if (!context.performed) { return; }

        Debug.Log("ESC key performed!");

        if (menuCanvas != null)
        {
            Debug.Log($"Canvas found! Current state: {menuCanvas.gameObject.activeSelf}");
            
            // Toggle canvas visibility
            menuCanvas.gameObject.SetActive(!menuCanvas.gameObject.activeSelf);
            
            // Pause/unpause the game
            if (menuCanvas.gameObject.activeSelf)
            {
                Time.timeScale = 0f; // Pause game
                Cursor.visible = true; // Make cursor visible for UI
                Cursor.lockState = CursorLockMode.None; // Unlock cursor for UI interaction
                Debug.Log("Game paused! Cursor enabled for UI.");
            }
            else
            {
                Time.timeScale = 1f; // Resume game
                Cursor.visible = false; // Hide cursor for gameplay
                Cursor.lockState = CursorLockMode.Locked; // Lock cursor for gameplay
                Debug.Log("Game resumed! Cursor locked for gameplay.");
            }
        }
        else
        {
            // Simple test without canvas - just toggle time scale
            Debug.LogWarning("Menu Canvas is not assigned! Testing pause/resume only.");
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Game paused (no UI)! Cursor enabled.");
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Game resumed (no UI)! Cursor locked.");
            }
        }
    }

    public void OnELight(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        Debug.Log("E key pressed!");
        
        ELightEvent?.Invoke();
    }
}
