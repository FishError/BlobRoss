using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBaseIdleState : MobBaseState
{
    protected float idleTime;

    public MobBaseIdleState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, string animName) : base(enemy, stateMachine, data, animName) { }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        SetRandomIdleTime();
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
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
        idleTime = Random.Range(data.MinIdleDuration, data.MaxIdleDuration);
    }
}
