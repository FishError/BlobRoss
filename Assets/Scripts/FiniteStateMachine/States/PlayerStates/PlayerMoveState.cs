using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
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
            if(!leftClick) SetMove(xInput,yInput);
            player.LastX = xInput;
            player.LastY = yInput;
            player.SetVelocityX(playerData.MovementSpeed * xInput);
        }
        if (yInput > 0 || yInput < 0)
        {
            if(!leftClick) SetMove(xInput,yInput);
            player.LastX = xInput;
            player.LastY = yInput;
            player.SetVelocityY(playerData.MovementSpeed * yInput);
        }
        if (xInput == 0f && yInput == 0f)
        {
            SetIdle(player.LastX, player.LastY);
            stateMachine.ChangeState(player.IdleState);
        }
        if (xInput == 0f && yInput != 0f)
        {
            if (!leftClick) SetMove(xInput, yInput);
            SetIdle(player.LastX, player.LastY);
            player.LastY = yInput;
            player.SetVelocityX(playerData.MovementSpeed * xInput);
        }
        if (xInput != 0f && yInput == 0f)
        {
            if (!leftClick) SetMove(xInput, yInput);
            SetIdle(player.LastX, player.LastY);
            player.LastX = xInput;
            player.SetVelocityY(playerData.MovementSpeed * yInput);
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

}
