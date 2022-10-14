using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentIdleState : EquipmentGroundedStates
{
    public EquipmentIdleState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

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
        if(xInput != 0 || yInput != 0)
        {
            stateMachine.ChangeState(equipment.MoveState);
        }
        
        if(leftClickInput && equipment.color == "red"){
            stateMachine.ChangeState(equipment.EffectState);
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
