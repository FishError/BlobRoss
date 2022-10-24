using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected float idleTime;

    public EnemyIdleState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData) { }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0);
        enemy.SetVelocityY(0);
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (enemy.TargetDetected())
        {
            stateMachine.ChangeState(enemy.AlertedState);
            return;
        }
        else if (Time.time >= startTime + idleTime)
        {
            stateMachine.ChangeState(enemy.PatrolState);
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

    protected void SetRandomIdleTime()
    {
        idleTime = Random.Range(enemyData.MinIdleDuration, enemyData.MaxIdleDuration);
    }
}
