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
        if (equipment.Anim == null) return;
        base.LogicUpdate();
        if (xInput > 0 || xInput < 0)
        {
            if(!leftClickInput) SetMove(xInput,yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (yInput > 0 || yInput < 0)
        {
            if (!leftClickInput) SetMove(xInput, yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (xInput == 0f && yInput == 0f)
        {
            SetIdle(equipment.LastX,equipment.LastY);
            equipment.Anim.SetFloat("offset",0f);
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

        /* 
            If Equipment enters Move state but effect animation 
            is still playing, sync equipment and blob animation
        */ 
        if(!equipment.Anim.GetCurrentAnimatorStateInfo(0).IsName("Move")){
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
