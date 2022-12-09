using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public float NormInputX { get; private set; }
    public float NormInputY { get; private set; }
    public bool leftClickInput { get; private set; }
    public bool rightClickInput { get; private set; }
    public bool spaceClickInput { get; private set; }

    private void OnMovement(InputValue value)
    {
        RawMovementInput = value.Get<Vector2>();
    }

    private void OnAttack(InputValue value)
    {

        if (value.Get<float>() == 1){
            leftClickInput = true;
        } else {
            leftClickInput = false;
        }
    } 


    // OnDefend
    private void OnDefend(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            rightClickInput = true;
        }
        else
        {
            rightClickInput = false;
        }
    }

    // OnUtil
    private void OnDash(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            spaceClickInput = true;
        }
        else
        {
            spaceClickInput = false;
        }
    }


    private void FixedUpdate()
    {
        NormInputX = (float)RawMovementInput.x;
        NormInputY = (float)RawMovementInput.y;
    }
}
