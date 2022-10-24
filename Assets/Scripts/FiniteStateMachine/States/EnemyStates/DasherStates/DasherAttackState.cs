using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAttackState : EnemyAttackState
{
    protected Vector2 attackDirection;
    protected float attackDuration = 0.5f;
    protected float chargeUpTime = 1f;

    public DasherAttackState(Dasher enemy, FiniteStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData) { }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        attackDirection = (enemy.target.transform.position - enemy.transform.position).normalized;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        float distance = Vector2.Distance(enemy.target.transform.position, enemy.transform.position);
        if (distance > enemyData.AttackRange)
        {
            stateMachine.ChangeState(enemy.AgroState);
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
        if (Time.time > startTime + chargeUpTime && Time.time < startTime + chargeUpTime + attackDuration)
        {
            enemy.rb.velocity = attackDirection * enemy.MovementVelocity * 2;
        }
        else
        {
            enemy.rb.velocity = Vector2.zero;
        }
    }
}
