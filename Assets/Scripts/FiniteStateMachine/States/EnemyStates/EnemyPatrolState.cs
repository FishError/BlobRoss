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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.SetVelocity(enemy.PatrolVelocity, patrolDirection);

        if (Vector2.Distance(enemy.transform.position, startPosition) >= patrolDistance)
            stateMachine.ChangeState(enemy.IdleState);
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomPatrolDirection()
    {
        Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        patrolDirection = randomVector.normalized;
    }

    private void SetRandomPatrolDistance()
    {
        patrolDistance = Random.Range(2f, 4f);
    }
}
