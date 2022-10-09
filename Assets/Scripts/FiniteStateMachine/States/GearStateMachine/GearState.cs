using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearState : EntityState
{
    protected Gear gear;
    protected GearData gearData;
    protected float startTime;
    private string animName;

    public GearState(Gear gear, FiniteStateMachine stateMachine, GearData gearData, string animName)
    {
        this.gear = gear;
        this.stateMachine = stateMachine;
        this.gearData = gearData;
        this.animName = animName;
    }

    //Gets called when entered a specific state
    public override void Enter()
    {
        DoChecks();
        //gear.anim.SetBool(animName, true);
        startTime = Time.time;
    }

    //Gets called when leaving a specific state
    public override void Exit()
    {
        //gear.anim.SetBool(animName, false);
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
