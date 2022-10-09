using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearGroundedStates : GearState
{

    public GearGroundedStates(Gear gear, FiniteStateMachine stateMachine, GearData gearData, string animName) : base(gear, stateMachine, gearData, animName) { }

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
