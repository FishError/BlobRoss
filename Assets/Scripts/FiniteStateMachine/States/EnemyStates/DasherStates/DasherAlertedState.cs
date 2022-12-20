using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAlertedState : DasherState
{
    protected float alertTime;

    public DasherAlertedState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) { }

    public override void Enter()
    {
        base.Enter();
        dasher.rb.velocity = Vector2.zero;
        dasher.alerted = true;
        dasher.lookAt = (dasher.target.transform.position - dasher.transform.position).normalized;
        dasher.SetAnimHorizontalVertical(dasher.lookAt);
        dasher.transform.Find("Alert").gameObject.SetActive(true);
        alertTime = data.AlertTime;
    }

    public override void Exit()
    {
        base.Exit();
        dasher.SetAnimHorizontalVertical(dasher.lookAt);
        dasher.transform.Find("Alert").gameObject.SetActive(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + alertTime)
        {
            stateMachine.ChangeState(dasher.AgroState);
            return;
        }

        dasher.lookAt = (dasher.target.transform.position - dasher.transform.position).normalized;
        dasher.SetAnimHorizontalVertical(dasher.lookAt);
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
