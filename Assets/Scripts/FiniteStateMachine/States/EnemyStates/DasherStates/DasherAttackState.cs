using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAttackState : EnemyAttackState
{
    private Dasher dasher;
    private DasherData data;

    protected static float attackChargeUpTime = 0.5f;

    public DasherAttackState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) 
    {
        this.dasher = dasher;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        dasher.rb.velocity = Vector2.zero;
        dasher.lookAt = targetDirection;
        dasher.SetAnimHorizontalVertical(dasher.lookAt);
    }

    public override void Exit()
    {
        base.Exit();
        dasher.rb.velocity = Vector2.zero;
        dasher.AttackCoolDown = 1 / data.AttackSpeed;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        ChangeStateAfterAnimation(animName, dasher.AgroState);
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        AnimatorStateInfo animState = dasher.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("Attack") && animState.normalizedTime >= attackChargeUpTime)
        {
            dasher.rb.velocity = targetDirection * dasher.MovementSpeed * dasher.DashSpeedRatio;
        }
    }

    public override void OnCollisionEnter(Collision2D collision)
    {
        base.OnCollisionEnter(collision);
        if (Time.time > startTime + attackChargeUpTime)
        {
            if (collision.gameObject.tag == "Player")
                collision.gameObject.GetComponent<Player>().ModifyHealthPoints(-dasher.Attack * dasher.DashDamageRatio);

            dasher.CCState.SetKnockbackValues(collision.GetContact(0).normal * dasher.KnockbackForce, dasher.KnockbackDuration);
            stateMachine.ChangeState(dasher.CCState);
        }
    }
}
