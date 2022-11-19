using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieAlertedState : EnemyAlertedState
{
    public ArchieAlertedState(Archie archie, FiniteStateMachine stateMachine, ArchieData data, string animName) : base(archie, stateMachine, data, animName)
    {
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
