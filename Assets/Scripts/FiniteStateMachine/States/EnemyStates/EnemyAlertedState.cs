using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertedState : EnemyState
{
    protected float alertTime;

    public EnemyAlertedState(Enemy enemy, FiniteStateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0);
        enemy.SetVelocityY(0);
        enemy.lookAt = enemy.target.transform.position - enemy.transform.position;
        alertTime = 0.5f;
        // play enemy alerted animation (if we have one)
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + alertTime)
        {
            stateMachine.ChangeState(enemy.ChaseTargetState);
            return;
        }

        enemy.lookAt = enemy.target.transform.position - enemy.transform.position;
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
