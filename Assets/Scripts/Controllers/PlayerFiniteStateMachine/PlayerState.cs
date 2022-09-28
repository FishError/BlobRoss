using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;

    private string animName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animName = animName;
    }

    //Gets called when entered a specific state
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animName, true);
        startTime = Time.time;
        Debug.Log(animName);
    }

    //Gets called when leaving a specific state
    public virtual void Exit()
    {
        player.Anim.SetBool(animName, false);
    }

    //Gets called every frame
    public virtual void LogicUpdate()
    {

    }

    //Gets called every FixedUpdate
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    //Check for Walls/Grounded etc
    public virtual void DoChecks()
    {

    }
}
