using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blomb : Enemy
{
    public GameObject fieldOnDeath;

    public float ExplosionDamage;
    public float KnockbackForce;
    public float KnockbackDuration;

    protected override void Awake()
    {
        base.Awake();
        IdleState = new BlombIdleState(this, StateMachine, (EnemyData)data, "Idle");
        PatrolState = new BlombPatrolState(this, StateMachine, (EnemyData)data, "Move");
        AlertedState = new BlombAlertedState(this, StateMachine, (EnemyData)data, "Idle");
        AgroState = new BlombAgroState(this, StateMachine, (EnemyData)data, "Move");
        AttackState = new BlombAttackState(this, StateMachine, (EnemyData)data, "Attack");
        CCState = new EnemyCCState(this, StateMachine, (EnemyData)data, "Idle");
        DeathState = new BlombDeathState(this, StateMachine, (EnemyData)data, "Death");
    }

    protected override void Start()
    {
        base.Start();
        ExplosionDamage = ((BlombData)data).ExplosionDamage;
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
