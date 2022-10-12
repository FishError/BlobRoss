using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected float idleTime;

    public EnemyIdleState(Enemy enemy, FiniteStateMachine stateMachine) : base(enemy, stateMachine) { }

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
        
        if (Time.time >= startTime + idleTime)
            stateMachine.ChangeState(enemy.PatrolState);
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(1f, 2f);
    }
}
