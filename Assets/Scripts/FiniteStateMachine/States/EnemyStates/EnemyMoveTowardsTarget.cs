using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTowardsTarget : EnemyState
{
    public EnemyMoveTowardsTarget(Enemy enemy, FiniteStateMachine stateMachine) : base(enemy, stateMachine) { }

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
