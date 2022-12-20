using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherIdleState : DasherState
{
    protected float idleTime;

    public DasherIdleState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) { }

    public override void Enter()
    {
        base.Enter();
        dasher.rb.velocity = Vector2.zero;
        SetRandomIdleTime();
        dasher.SetAnimHorizontalVertical(dasher.lookAt);
    }

    public override void Exit()
    {
        base.Exit();
        dasher.SetAnimHorizontalVertical(dasher.lookAt);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (dasher.TargetDetected())
        {
            stateMachine.ChangeState(dasher.AlertedState);
            return;
        }
        else if (Time.time >= startTime + idleTime)
        {
            stateMachine.ChangeState(dasher.PatrolState);
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
