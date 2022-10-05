using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedStates : PlayerState
{
    protected float xInput;
    protected float yInput;
    protected Animator redGearAnim;

    public PlayerGroundedStates(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    
    }

    public override void DoChecks()
    {
        base.DoChecks();
        redGearAnim = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Animator>();
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

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
