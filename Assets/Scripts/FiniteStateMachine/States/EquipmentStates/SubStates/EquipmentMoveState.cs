using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMoveState : EquipmentGroundedStates
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
        if(leftClickInput && equipment.color == "red"){
            stateMachine.ChangeState(equipment.EffectState);
        } 
        if (xInput > 0 || xInput < 0)
        {
            SetHorizontalAnimation();
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (yInput > 0 || yInput < 0)
        {
            SetVerticalAnimation();
            equipment.LastX = xInput;
            equipment.LastY = yInput;
        }
        if (xInput == 0f && yInput == 0f)
        {
            SetIdleAnimation();
            stateMachine.ChangeState(equipment.IdleState);
        }
        if (xInput == 0f && yInput != 0f)
        {
            SetOnlyVerticalAnimation();
            equipment.LastY = yInput;
        }
        if (xInput != 0f && yInput == 0f)
        {
            SetOnlyHorizontalAnimation();
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

    public void SetHorizontalAnimation()
    {
        SetMove();
    }

    public void SetVerticalAnimation()
    {
        SetMove();
    }

    public void SetIdleAnimation()
    {
        SetIdle();
    }

    public void SetOnlyVerticalAnimation()
    {
        SetIdle();
    }

    public void SetOnlyHorizontalAnimation()
    {
        SetIdle();
    }

    // Setting the equipment's Move Blend tree animation based on player input
    public void SetMove()
    {
        equipment.Anim.SetFloat("Horizontal", xInput);
        equipment.Anim.SetFloat("Vertical", yInput);
    }

    public void SetIdle()
    {
        equipment.Anim.SetFloat("IdleHorizontal", equipment.LastX);
        equipment.Anim.SetFloat("IdleVertical", equipment.LastY);
    }

}
