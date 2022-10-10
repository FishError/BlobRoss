using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedStates : PlayerState
{
    protected float xInput;
    protected float yInput;

    public PlayerGroundedStates(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName) {}

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
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
 
        redEquipment.IdleState.XInput = xInput;
        redEquipment.IdleState.YInput = yInput;
        redEquipment.MoveState.XInput = xInput;
        redEquipment.MoveState.YInput = yInput;

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
