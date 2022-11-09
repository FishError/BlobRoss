using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAttack
{
    // references
    protected string animName;

    // attack stats
    public float DamageRatio { get; set; }
    public float Range { get; set; }
    public float Cooldown { get; set; }

    public float CooldownTimer { get; set; }

    public BossAttack(string animName)
    {
        this.animName = animName;

        CooldownTimer = Time.time;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {
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
