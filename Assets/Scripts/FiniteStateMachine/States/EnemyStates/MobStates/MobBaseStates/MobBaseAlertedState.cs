using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBaseAlertedState : MobBaseState
{
    protected float alertTime;

    public MobBaseAlertedState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, Animator animator, string animName) : base(enemy, stateMachine, data, animator, animName) { }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        enemy.alerted = true;
        enemy.lookAt = (enemy.target.transform.position - enemy.transform.position).normalized;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
        enemy.transform.Find("Alert").gameObject.SetActive(true);
        alertTime = data.AlertTime;
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
