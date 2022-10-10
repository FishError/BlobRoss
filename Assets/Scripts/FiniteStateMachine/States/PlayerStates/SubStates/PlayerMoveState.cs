using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedStates
{
    public PlayerMoveState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName) {}

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
            player.LastX = xInput;
            player.LastY = yInput;
            player.SetVelocityX(playerData.MovementVelocity * xInput);
        }
        if (yInput > 0 || yInput < 0)
        {
            SetVerticalAnimation();
            player.LastX = xInput;
            player.LastY = yInput;
            player.SetVelocityY(playerData.MovementVelocity * yInput);
        }
        if (xInput == 0f && yInput == 0f)
        {
            SetIdleAnimation();
            stateMachine.ChangeState(player.IdleState);
        }
        if (xInput == 0f && yInput != 0f)
        {
            SetOnlyVerticalAnimation();
            player.LastY = yInput;
            player.SetVelocityX(playerData.MovementVelocity * xInput);
        }
        if (xInput != 0f && yInput == 0f)
        {
            SetOnlyHorizontalAnimation();
            player.LastX = xInput;
            player.SetVelocityY(playerData.MovementVelocity * yInput);
        }
        
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
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

    public void SetMove()
    {
        player.Anim.SetFloat("Horizontal", xInput);
        player.Anim.SetFloat("Vertical", yInput);
    }

    public void SetIdle()
    {
        player.Anim.SetFloat("IdleHorizontal", player.LastX);
        player.Anim.SetFloat("IdleVertical", player.LastY);
    }

}
