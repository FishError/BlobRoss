using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAttackState : EnemyAttackState
{
    protected static float attackChargeUpTime = 0.5f;

    public DasherAttackState(Dasher enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) 
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        enemy.lookAt = targetDirection;
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

        ChangeStateAfterAnimation(animName, enemy.AgroState);
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        AnimatorStateInfo animState = enemy.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("Attack") && animState.normalizedTime >= attackChargeUpTime)
        {
            enemy.rb.velocity = targetDirection * enemy.MovementSpeed * ((Dasher)enemy).DashSpeedRatio;
        }
    }

    public override void OnCollisionEnter(Collision2D collision)
    {
        base.OnCollisionEnter(collision);
        if (Time.time > startTime + attackChargeUpTime)
        {
            if (collision.gameObject.tag == "Player")
                collision.gameObject.GetComponent<Player>().ModifyHealthPoints(-enemy.Attack * ((Dasher)enemy).DashDamageRatio);

            enemy.CCState.SetKnockbackValues(collision.GetContact(0).normal * ((Dasher)enemy).KnockbackForce, ((Dasher)enemy).KnockbackDuration);
            stateMachine.ChangeState(enemy.CCState);
        }
    }
}
