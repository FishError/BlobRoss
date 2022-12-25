using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBasePatrolState : MobBaseState
{
    protected float patrolDistance;
    protected Vector2 patrolDirection;

    public MobBasePatrolState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, Animator animator, string animName) : base(enemy, stateMachine, data, animator, animName) { }

    public override void Enter()
    {
        base.Enter();
        SetRandomPatrolDistance();
        SetRandomPatrolDirection();
        enemy.lookAt = patrolDirection;
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
        enemy.SetVelocity(enemy.PatrolSpeed, patrolDirection);
    }

    protected void SetRandomPatrolDirection()
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

    protected void SetRandomPatrolDistance()
    {
        patrolDistance = Random.Range(data.MinPatrolDistance, data.MaxPatrolDistance);
    }
}
