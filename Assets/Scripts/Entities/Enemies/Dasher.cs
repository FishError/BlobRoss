using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : Enemy
{
    public float DashDamageRatio { get; set; }
    public float DashSpeedRatio { get; set; }
    public float KnockbackForce { get; set; }
    public float KnockbackDuration { get; set; }

    protected override void Awake()
    {
        base.Awake();
        IdleState = new DasherIdleState(this, StateMachine, (EnemyData)data, "Idle");
        PatrolState = new DasherPatrolState(this, StateMachine, (EnemyData)data, "Move");
        AlertedState = new DasherAlertedState(this, StateMachine, (EnemyData)data, "Alerted");
        AgroState = new DasherAgroState(this, StateMachine, (EnemyData)data, "Move");
        AttackState = new DasherAttackState(this, StateMachine, (EnemyData)data, "Attack");
        CCState = new DasherCCState(this, StateMachine, (EnemyData)data, "Idle");
        DeathState = new DasherDeathState(this, StateMachine, (EnemyData)data, "Death");
    }

    protected override void Start()
    {
        base.Start();
        DashDamageRatio = ((DasherData)data).DashDamageRatio;
        DashSpeedRatio = ((DasherData)data).DashSpeedRatio;
        KnockbackForce = ((DasherData)data).KnockbackForce;
        KnockbackDuration = ((DasherData)data).KnockbackDuration;
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
