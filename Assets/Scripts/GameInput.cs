using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameInput : MonoBehaviour
{
    
    private PlayerInputActions playerInputActions;
    public event EventHandler OnLampStateChanged;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.LampOnOff.performed += LampStateChangeBroadcast;
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

    private void LampStateChangeBroadcast(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnLampStateChanged?.Invoke(this,EventArgs.Empty);   
        }
    }
}
