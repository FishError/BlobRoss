using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : MobEnemyState
{
    protected Vector2 targetDirection;
    public EnemyAttackState(MobEnemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) { }

    public override void Enter()
    {
        base.Enter();
        targetDirection = ((Vector2)(enemy.target.transform.position - enemy.transform.position)).normalized;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        targetDirection = ((Vector2)(enemy.target.transform.position - enemy.transform.position)).normalized;
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
