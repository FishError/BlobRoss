using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAttack
{
    // references
    protected Animator animator;
    protected string animName;

    // attack stats
    public float DamageRatio { get; set; }
    public float Range { get; set; }
    public float Cooldown { get; set; }

    public float CooldownTimer { get; set; }

    public BossAttack(Animator animator, string animName)
    {
        this.animator = animator;
        this.animName = animName;

        CooldownTimer = Time.time;
    }

    public virtual void Enter()
    {
        animator.SetBool(animName, true);
    }

    public virtual void Exit()
    {
        animator.SetBool(animName, false);
        CooldownTimer = Time.time + Cooldown;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual bool OnCooldown()
    {
        return Time.time < CooldownTimer;
    }
}
