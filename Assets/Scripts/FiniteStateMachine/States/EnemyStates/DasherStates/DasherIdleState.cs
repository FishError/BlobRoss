using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherIdleState : EnemyIdleState
{
    public DasherIdleState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) { }

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

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
