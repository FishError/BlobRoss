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
        enemy.rb.velocity = Vector2.zero;
        enemy.alerted = true;
        enemy.lookAt = (enemy.target.transform.position - enemy.transform.position).normalized;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
        enemy.transform.Find("Alert").gameObject.SetActive(true);
        alertTime = enemyData.AlertTime;
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
        enemy.transform.Find("Alert").gameObject.SetActive(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + alertTime)
        {
            stateMachine.ChangeState(((MobEnemy)enemy).AgroState);
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
