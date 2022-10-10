using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMoveState : GearGroundedStates
{
    public GearMoveState(Gear gear, FiniteStateMachine stateMachine, GearData gearData, string animName) : base(gear, stateMachine, gearData, animName) {}

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
            SetHorizontalAnimation();
            gear.LastX = xInput;
            gear.LastY = yInput;
        }
        if (yInput > 0 || yInput < 0)
        {
            SetVerticalAnimation();
            gear.LastX = xInput;
            gear.LastY = yInput;
        }
        if (xInput == 0f && yInput == 0f)
        {
            SetIdleAnimation();
            stateMachine.ChangeState(gear.IdleState);
        }
        if (xInput == 0f && yInput != 0f)
        {
            SetOnlyVerticalAnimation();
            gear.LastY = yInput;
        }
        if (xInput != 0f && yInput == 0f)
        {
            SetOnlyHorizontalAnimation();
            gear.LastX = xInput;
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

    // Setting the gear's Move Blend tree animation based on player input
    public void SetMove()
    {
        gear.Anim.SetFloat("Horizontal", xInput);
        gear.Anim.SetFloat("Vertical", yInput);
    }

    public void SetIdle()
    {
        gear.Anim.SetFloat("IdleHorizontal", gear.LastX);
        gear.Anim.SetFloat("IdleVertical", gear.LastY);
    }

}
