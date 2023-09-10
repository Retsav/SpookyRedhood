using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInputActions playerInputActions;

    [SerializeField] private float playerMovementSpeed = 5f;
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    
    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        playerRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y)*playerMovementSpeed, ForceMode.Force);
    }
}
