using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blomb : MobEnemy
{
    public GameObject fieldOnDeath;

    public float ExplosionDamageRatio { get; set; }
    public float KnockbackForce { get; set; }
    public float KnockbackDuration { get; set; }

    protected override void Awake()
    {
        base.Awake();
        IdleState = new BlombIdleState(this, StateMachine, (BlombData)data, "Idle");
        PatrolState = new BlombPatrolState(this, StateMachine, (BlombData)data, "Move");
        AlertedState = new BlombAlertedState(this, StateMachine, (BlombData)data, "Idle");
        AgroState = new BlombAgroState(this, StateMachine, (BlombData)data, "Move");
        AttackState = new BlombAttackState(this, StateMachine, (BlombData)data, "Attack");
        CCState = new EnemyCCState(this, StateMachine, (BlombData)data, "Idle");
        DeathState = new BlombDeathState(this, StateMachine, (BlombData)data, "Death");
    }

    protected override void Start()
    {
        base.Start();
        ExplosionDamageRatio = ((BlombData)data).ExplosionDamageRatio;
        KnockbackForce = ((BlombData)data).KnockbackForce;
        KnockbackDuration = ((BlombData)data).KnockbackDuration;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
