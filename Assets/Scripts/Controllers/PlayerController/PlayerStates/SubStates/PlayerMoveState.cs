using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedStates
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

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
            player.Anim.SetFloat("Horizontal", xInput);
            player.Anim.SetFloat("Vertical", yInput);
            player.LastX = xInput;
            player.LastY = yInput;
            player.SetVelocityX(playerData.movementVelocity * xInput);
        }
        if (yInput > 0 || yInput < 0)
        {
            player.Anim.SetFloat("Vertical", yInput);
            player.Anim.SetFloat("Horizontal", xInput);
            player.LastX = xInput;
            player.LastY = yInput;
            player.SetVelocityY(playerData.movementVelocity * yInput);
        }
        if (xInput == 0f && yInput == 0f)
        {
            player.Anim.SetFloat("IdleHorizontal", player.LastX);
            player.Anim.SetFloat("IdleVertical", player.LastY);
            stateMachine.ChangeState(player.IdleState);
        }
        if (xInput == 0f && yInput != 0f)
        {
            player.Anim.SetFloat("IdleHorizontal", player.LastX);
            player.Anim.SetFloat("IdleVertical", player.LastY);
            player.LastY = yInput;
            player.SetVelocityX(playerData.movementVelocity * xInput);
        }
        if (xInput != 0f && yInput == 0f)
        {
            player.Anim.SetFloat("IdleHorizontal", player.LastX);
            player.Anim.SetFloat("IdleVertical", player.LastY);
            player.LastX = xInput;
            player.SetVelocityY(playerData.movementVelocity * yInput);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
