using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    protected float patrolDistance;
    protected Vector2 patrolDirection;

    public EnemyPatrolState(Enemy enemy, FiniteStateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        SetRandomPatrolDistance();
        SetRandomPatrolDirection();
        enemy.lookAt = patrolDirection;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // change state if conditions are met
        if (enemy.TargetDetected())
        {
            stateMachine.ChangeState(enemy.AlertedState);
            return;
        }
        else if (Vector2.Distance(enemy.transform.position, startPosition) >= patrolDistance)
        {
            stateMachine.ChangeState(enemy.IdleState);
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

        enemy.lookAt = patrolDirection;
        enemy.SetVelocity(enemy.PatrolVelocity, patrolDirection);
    }

    private void SetRandomPatrolDirection()
    {
        Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        RaycastHit2D hit = Physics2D.CircleCast(enemy.transform.position, 0.6f, randomVector, patrolDistance, enemy.unWalkableLayers);
        if (hit.collider == null)
        {
            patrolDirection = randomVector.normalized;
        }
        else
        {
            patrolDirection = ((Vector3)(hit.point + hit.normal * patrolDistance) - enemy.transform.position).normalized;
        }
    }

    private void SetRandomPatrolDistance()
    {
        patrolDistance = Random.Range(2f, 4f);
    }
}
