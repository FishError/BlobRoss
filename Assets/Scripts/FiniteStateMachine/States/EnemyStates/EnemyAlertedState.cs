using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertedState : EnemyState
{
    protected float alertTime;

    public EnemyAlertedState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) { }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0);
        enemy.SetVelocityY(0);
        enemy.lookAt = (enemy.target.transform.position - enemy.transform.position).normalized;
        alertTime = enemyData.AlertTime;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
        // play enemy alerted animation (if we have one)
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + alertTime)
        {
            stateMachine.ChangeState(enemy.AgroState);
            return;
        }

        enemy.lookAt = (enemy.target.transform.position - enemy.transform.position).normalized;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
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
