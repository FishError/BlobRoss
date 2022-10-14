using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEquipmentEffectState : EquipmentEffectState
{

    public RedEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        HandelAnimation();
        Debug.Log("You inflicted 100 attack damage");
        /*Put any red equipment related effects here:
            DamageInfliction();
            AddingColor();
        */

    }

    private void HandelAnimation(){

        //When using effect
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

    


}
