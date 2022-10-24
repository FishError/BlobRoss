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
        redEquipment.IdleState.LeftClickInput = player.InputHandler.leftClickInput;

        redEquipment.MoveState.XInput = xInput;
        redEquipment.MoveState.YInput = yInput;
        redEquipment.MoveState.LeftClickInput = player.InputHandler.leftClickInput;

        redEquipment.EffectState.XInput = xInput;
        redEquipment.EffectState.YInput = yInput;
        redEquipment.EffectState.LeftClickInput = player.InputHandler.leftClickInput;

        //Blue Equipment
        blueEquipment.IdleState.XInput = xInput;
        blueEquipment.IdleState.YInput = yInput;
        blueEquipment.IdleState.RightClickInput = player.InputHandler.rightClickInput;

        blueEquipment.MoveState.XInput = xInput;
        blueEquipment.MoveState.YInput = yInput;
        blueEquipment.MoveState.RightClickInput = player.InputHandler.rightClickInput;

        //blueEquipment.EffectState.XInput = xInput;
        //blueEquipment.EffectState.YInput = yInput;
        blueEquipment.EffectState.RightClickInput = player.InputHandler.rightClickInput;

        //copy 9 lines above for yellow & blue

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
