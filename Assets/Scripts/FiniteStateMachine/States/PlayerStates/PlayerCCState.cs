using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCCState : PlayerState
{
    public CrowdControl crowdControlType { get; set; }

    protected Vector2 knockbackForce;
    protected float knockbackDuration;

    protected float otherCCDuration;

    public PlayerCCState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName) { }

    public override void Enter()
    {
        base.Enter();

        player.rb.velocity = Vector2.zero;
        switch (crowdControlType)
        {
            case CrowdControl.Knockback:
                player.rb.AddForce(knockbackForce, ForceMode2D.Impulse);
                break;
            case CrowdControl.Stunned:
            case CrowdControl.Frozen:
            case CrowdControl.Snarred:
                player.rb.velocity = Vector2.zero;
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
                    if (xInput != 0 || yInput != 0)
                        stateMachine.ChangeState(player.MoveState);
                    else
                        stateMachine.ChangeState(player.IdleState);
                    return;
                }
                break;
            case CrowdControl.Stunned:
            case CrowdControl.Frozen:
            case CrowdControl.Snarred:
                if (Time.time > startTime + otherCCDuration)
                {
                    if (xInput != 0 || yInput != 0)
                        stateMachine.ChangeState(player.MoveState);
                    else
                        stateMachine.ChangeState(player.IdleState);
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
