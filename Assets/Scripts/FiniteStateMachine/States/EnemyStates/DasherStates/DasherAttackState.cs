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
        enemy.Anim.SetFloat("MoveHorizontal", attackDirection.x);
        enemy.Anim.SetFloat("MoveVertical", attackDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.rb.velocity = Vector2.zero;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > startTime + attackChargeUpTime && enemy.collision != null)
        {
            enemy.CCState.SetKnockbackValues(enemy.collision.GetContact(0).normal * 4, 0.4f);
            stateMachine.ChangeState(enemy.CCState);
            return;
        }
        else if (Time.time > startTime + attackDuration + attackChargeUpTime)
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
            enemy.rb.velocity = attackDirection * enemy.MovementVelocity * 2;
        }
    }
}
