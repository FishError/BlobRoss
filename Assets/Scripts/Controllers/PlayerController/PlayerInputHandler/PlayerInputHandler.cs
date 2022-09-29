using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public float NormInputX { get; private set; }
    public float NormInputY { get; private set; }

    private void OnMovement(InputValue value)
    {
        RawMovementInput = value.Get<Vector2>();
        
    }

    private void FixedUpdate()
    {
        NormInputX = (float)RawMovementInput.x;
        NormInputY = (float)RawMovementInput.y;

    }
}
