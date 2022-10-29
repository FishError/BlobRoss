using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEquipmentEffectState : EquipmentEffectState
{

    public RedEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        HandleAnimation();
        
        Debug.Log("You inflicted 100 attack damage");
        /*Put any red equipment related effects here:
            DamageInfliction();
            AddingColor();
        */

    }

    //TODO: Might move this a level up
    private void HandleAnimation(){
        //When using equipment's effect
        if (leftClickInput){
            if (xInput > 0 || xInput < 0)
            {
                SetEffect(xInput,yInput);
                equipment.LastX = xInput;
                equipment.LastY = yInput;
            }
            if (yInput > 0 || yInput < 0)
            {
                SetEffect(xInput,yInput);
                equipment.LastX = xInput;
                equipment.LastY = yInput;
            }
            if (xInput == 0f && yInput == 0f)
            {
                SetEffect(equipment.LastX,equipment.LastY);
            }
            if (xInput == 0f && yInput != 0f)
            {
                SetEffect(equipment.LastX,equipment.LastY);
                equipment.LastY = yInput;
            }
            if (xInput != 0f && yInput == 0f)
            {
                SetEffect(equipment.LastX,equipment.LastY);
                equipment.LastX = xInput;
            }

        }

        //When no longer using equipment's effect
        else if(xInput == 0f && yInput == 0f){
            SetIdle(equipment.LastX,equipment.LastY);
            stateMachine.ChangeState(equipment.IdleState);
        } else {
            stateMachine.ChangeState(equipment.MoveState);
        }

    }

}
