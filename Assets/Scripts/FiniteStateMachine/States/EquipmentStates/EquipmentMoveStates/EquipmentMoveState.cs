using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMoveState : EquipmentState
{
    public EquipmentMoveState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (xInput > 0 || xInput < 0)
        {
            SetMove(xInput,yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (yInput > 0 || yInput < 0)
        {
            SetMove(xInput,yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (xInput == 0f && yInput == 0f)
        {
            SetIdle(equipment.LastX,equipment.LastY);
            stateMachine.ChangeState(equipment.IdleState);
        }
        if (xInput == 0f && yInput != 0f)
        {
            SetIdle(equipment.LastX,equipment.LastY);
            equipment.LastY = yInput;
        }
        if (xInput != 0f && yInput == 0f)
        {
            SetIdle(equipment.LastX,equipment.LastY);
            equipment.LastX = xInput;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
