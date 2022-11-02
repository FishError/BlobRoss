using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieCCState : EnemyCCState
{
    public ArchieCCState(Archie enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName)
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
