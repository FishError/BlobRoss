using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentEffectState : EquipmentGroundedStates
{   
    
    public EquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //While using effect
        if(leftClickInput){
            if (xInput > 0 || xInput < 0)
            {
                SetEffectDirection(xInput,yInput);
                equipment.LastX = xInput;
                equipment.LastY = yInput;
            }
            if (yInput > 0 || yInput < 0)
            {
                SetEffectDirection(xInput,yInput);
                equipment.LastX = xInput;
                equipment.LastY = yInput;
            }
            if (xInput == 0f && yInput == 0f)
            {
                SetEffectDirection(equipment.LastX,equipment.LastY);
            }
            if (xInput == 0f && yInput != 0f)
            {
                SetEffectDirection(equipment.LastX,equipment.LastY);
                equipment.LastY = yInput;
            }
            if (xInput != 0f && yInput == 0f)
            {
                SetEffectDirection(equipment.LastX,equipment.LastY);
                equipment.LastX = xInput;
            }

        }

        //When no longer using effect
        if(equipment.LastX == 0 && equipment.LastY == 0){
            SetIdleAnimation();
            stateMachine.ChangeState(equipment.IdleState);
        } else {
            stateMachine.ChangeState(equipment.MoveState);
        }

    }

    // Setting the equipment's Move Blend tree animation based on player input
    public void SetEffectDirection(float x, float y)
    {
        equipment.Anim.SetFloat("EffectHorizontal", x);
        equipment.Anim.SetFloat("EffectVertical", y);
    }

    public void SetIdleAnimation()
    {
        equipment.Anim.SetFloat("IdleHorizontal", equipment.LastX);
        equipment.Anim.SetFloat("IdleVertical", equipment.LastY);
    }


}
