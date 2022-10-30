using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEquipmentEffectState : EquipmentEffectState
{
    public BlueEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName)
    {
    }


    public override void Enter()
    {
        base.Enter();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ActivateEffect();
    }

    private void ActivateEffect()
    {
        //When using effect

        if (xInput > 0 || xInput < 0)
        {
            SetEffect(xInput, yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (yInput > 0 || yInput < 0)
        {
            SetEffect(xInput, yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (xInput == 0f && yInput == 0f)
        {
            SetEffect(equipment.LastX, equipment.LastY);
        }
        if (xInput == 0f && yInput != 0f)
        {
            SetEffect(equipment.LastX, equipment.LastY);
            equipment.LastY = yInput;
        }
        if (xInput != 0f && yInput == 0f)
        {
            SetEffect(equipment.LastX, equipment.LastY);
            equipment.LastX = xInput;
        }
        //When no longer using equipment's effect
        else if (xInput == 0f && yInput == 0f)
        {
            SetIdle(equipment.LastX, equipment.LastY);
            stateMachine.ChangeState(equipment.IdleState);
        }
        else
        {
            stateMachine.ChangeState(equipment.MoveState);
        }

    }
}
