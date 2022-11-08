using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrowdControl
{
    Knockback,
    Stunned,
    Frozen,
    Snarred
}

public class EnemyCCState : MobEnemyState
{
    public CrowdControl crowdControlType { get; set; }

    protected Vector2 knockbackForce;
    protected float knockbackDuration;

    protected float otherCCDuration;

    public EnemyCCState(MobEnemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) { }

    public override void Enter()
    {
        base.Enter();
        
        switch (crowdControlType)
        {
            case CrowdControl.Knockback:
                enemy.rb.AddForce(knockbackForce, ForceMode2D.Impulse);
                break;
            case CrowdControl.Stunned:
            case CrowdControl.Frozen:
            case CrowdControl.Snarred:
                enemy.rb.velocity = Vector2.zero;
                break;
            default:
                break;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        switch (crowdControlType)
        {
            case CrowdControl.Knockback:
                if (Time.time > startTime + knockbackDuration)
                {
                    stateMachine.ChangeState(enemy.AgroState);
                    return;
                }
                break;
            case CrowdControl.Stunned:
            case CrowdControl.Frozen:
            case CrowdControl.Snarred:
                if (Time.time > startTime + otherCCDuration)
                {
                    stateMachine.ChangeState(enemy.AgroState);
                    return;
                }
                break;
            default:
                break;
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetKnockbackValues(Vector2 force, float duration)
    {
        crowdControlType = CrowdControl.Knockback;
        knockbackForce = force;
        knockbackDuration = duration;
    }

    public void SetOtherCCValues(CrowdControl type, float duration)
    {
        crowdControlType = type;
        otherCCDuration = duration;
    }
}
