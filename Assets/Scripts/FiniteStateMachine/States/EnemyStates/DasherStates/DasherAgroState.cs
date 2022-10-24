using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAgroState : EnemyAgroState
{
    public DasherAgroState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData) { }

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

        float distance = Vector2.Distance(enemy.target.transform.position, enemy.transform.position);
        if (distance <= enemyData.AttackRange)
        {
            stateMachine.ChangeState(enemy.AttackState);
            return;
        }
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
