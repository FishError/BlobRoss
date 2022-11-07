using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAttack
{
    // references
    protected Enemy enemy;
    protected EnemyData data;
    protected string animName;

    // attack stats
    public float DamageRatio { get; set; }
    public float Cooldown { get; set; }

    public BossAttack(Enemy enemy, EnemyData data, string animName)
    {
        this.enemy = enemy;
        this.data = data;
        this.animName = animName;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        
    }
}
