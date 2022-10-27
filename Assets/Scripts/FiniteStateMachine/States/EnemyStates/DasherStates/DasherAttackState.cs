using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAttackState : EnemyAttackState
{
    protected Vector2 attackDirection;
    protected float attackDuration = 0.5f;
    protected float attackChargeUpTime = 0.5f;

    public DasherAttackState(Dasher enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) 
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        attackDirection = (enemy.target.transform.position - enemy.transform.position).normalized;
        enemy.lookAt = attackDirection;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.rb.velocity = Vector2.zero;
        enemy.AttackCoolDown = 1 / enemyData.AttackSpeed;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > startTime + attackDuration + attackChargeUpTime)
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

        if (Time.time > startTime + attackChargeUpTime && Time.time < startTime + attackChargeUpTime + attackDuration)
        {
            enemy.rb.velocity = attackDirection * enemy.MovementSpeed * 2;
        }
    }

    public override void OnCollisionEnter(Collision2D collision)
    {
        if (Time.time > startTime + attackChargeUpTime)
        {
            enemy.CCState.SetKnockbackValues(collision.GetContact(0).normal * 5, 0.3f);
            stateMachine.ChangeState(enemy.CCState);
        }
    }
}
