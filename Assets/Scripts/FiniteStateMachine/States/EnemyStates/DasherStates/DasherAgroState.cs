using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAgroState : DasherState
{
    public DasherAgroState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) 
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

        // set NavMeshDestination to target position to update path every FixedUpdate loop
        dasher.navMeshAgent.nextPosition = dasher.transform.position;
        dasher.navMeshAgent.SetDestination(new Vector3(dasher.target.transform.position.x, dasher.target.transform.position.y, 0));
        dasher.rb.velocity = dasher.navMeshAgent.velocity;
        dasher.lookAt = dasher.rb.velocity.normalized;
        dasher.SetAnimHorizontalVertical(dasher.lookAt);
    }
}
