using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;
    protected PlayerData playerData;
    protected float startTime;

    private string animName, weapName;

    public PlayerState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animName = animName;
    }

    //Gets called when entered a specific state
    public override void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animName, true);
        startTime = Time.time;
    }

    //Gets called when leaving a specific state
    public override void Exit()
    {
        player.Anim.SetBool(animName, false);
    }

    //Gets called every frame
    public override void LogicUpdate()
    {

    }

    //Gets called every FixedUpdate
    public override void PhysicsUpdate()
    {
        DoChecks();
    }

    //Check for Walls/Grounded etc
    public override void DoChecks()
    {

    }
}
