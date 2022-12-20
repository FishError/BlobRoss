using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherPatrolState : DasherState
{
    protected float patrolDistance;
    protected Vector2 patrolDirection;

    public DasherPatrolState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) { }

    public override void Enter()
    {
        base.Enter();
        SetRandomPatrolDistance();
        SetRandomPatrolDirection();
        dasher.lookAt = patrolDirection;
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

        // change state if conditions are met
        if (dasher.TargetDetected())
        {
            stateMachine.ChangeState(dasher.AlertedState);
            return;
        }
        else if (Vector2.Distance(dasher.transform.position, startPosition) >= patrolDistance)
        {
            stateMachine.ChangeState(dasher.IdleState);
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
        dasher.lookAt = patrolDirection;
        dasher.SetVelocity(dasher.PatrolSpeed, patrolDirection);
    }

    protected void SetRandomPatrolDirection()
    {
        Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        RaycastHit2D hit = Physics2D.CircleCast(dasher.transform.position, 0.6f, randomVector, patrolDistance, dasher.unWalkableLayers);
        if (hit.collider == null)
        {
            patrolDirection = randomVector.normalized;
        }
        else
        {
            patrolDirection = ((Vector3)(hit.point + hit.normal * patrolDistance) - dasher.transform.position).normalized;
        }
    }

    protected void SetRandomPatrolDistance()
    {
        patrolDistance = Random.Range(data.MinPatrolDistance, data.MaxPatrolDistance);
    }
}
