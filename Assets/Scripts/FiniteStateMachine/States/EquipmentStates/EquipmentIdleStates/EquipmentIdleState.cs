using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentIdleState : EquipmentState
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
        if(equipment.Anim == null) return;
        base.LogicUpdate();
        if(xInput != 0 || yInput != 0)
        {
            equipment.Anim.SetFloat("offset",0f);
            stateMachine.ChangeState(equipment.MoveState);
        }

        /* 
            If Equipment enters Idle state but effect animation 
            is still playing, sync equipment and blob animation
        */ 
        if(!equipment.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            SyncAnimations();
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
