using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAgroState : DasherState
{
    public DasherAgroState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, Animator animator, string animName) : base(dasher, stateMachine, data, animator, animName) 
    {
        this.dasher = dasher;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();

        if (dasher.target == null)
        {
            stateMachine.ChangeState(dasher.IdleState);
            return;
        }

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

        if (dasher.target == null)
        {
            stateMachine.ChangeState(dasher.IdleState);
            return;
        }

        distance = Vector2.Distance(dasher.target.transform.position, dasher.transform.position);
        if (distance <= data.AttackRange && dasher.AttackCoolDown <= 0)
        {
            stateMachine.ChangeState(dasher.AttackState);
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

        NavigateToTarget(dasher);
    }
}
