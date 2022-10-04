using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedStates
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
        player.SetVelocityY(0f);
        if (redGearAnim)
        {
            redGearAnim.SetBool("WeaponIdle", true);
        }
    }

    public override void Exit()
    {
        base.Exit();
        if (redGearAnim)
        {
            redGearAnim.SetBool("WeaponIdle", false);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xInput != 0 || yInput != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
