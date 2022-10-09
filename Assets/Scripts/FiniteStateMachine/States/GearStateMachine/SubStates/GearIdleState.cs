using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearIdleState : GearGroundedStates
{
    public GearIdleState(Gear gear, FiniteStateMachine stateMachine, GearData gearData, string animName) : base(gear, stateMachine, gearData, animName) {}


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
