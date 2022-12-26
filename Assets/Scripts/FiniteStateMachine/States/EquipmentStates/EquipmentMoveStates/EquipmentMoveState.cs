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
        if (equipment.XInput != 0 || equipment.YInput != 0)
        {
            if(!equipment.LeftClickInput) SetMove(equipment.XInput,equipment.YInput);
            equipment.LastX = equipment.XInput;
            equipment.LastY = equipment.YInput;
        }
        else if (equipment.XInput == 0f && equipment.YInput == 0f)
        {
            if (!equipment.LeftClickInput)
            {
                SetIdle(equipment.LastX, equipment.LastY);
            }
            else
            {
                SetIdle(equipment.RedLastX, equipment.RedLastY);
            }
            equipment.Anim.SetFloat("offset",0f);
            stateMachine.ChangeState(equipment.IdleState);
        }
        else if (equipment.XInput == 0f && equipment.YInput != 0f)
        {
            SetIdle(equipment.LastX,equipment.LastY);
            equipment.LastY = equipment.YInput;
        }
        else if (equipment.XInput != 0f && equipment.YInput == 0f)
        {
            SetIdle(equipment.LastX,equipment.LastY);
            equipment.LastX = equipment.XInput;
        }

        /* 
            If Equipment enters Move state but effect animation 
            is still playing, sync both equipment move and blob move animations
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
