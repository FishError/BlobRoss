using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : MobEnemy
{
    public float DashDamageRatio { get; set; }
    public float DashSpeedRatio { get; set; }
    public float KnockbackForce { get; set; }
    public float KnockbackDuration { get; set; }

    protected override void Awake()
    {
        base.Awake();
        IdleState = new DasherIdleState(this, StateMachine, (DasherData)data, "Idle");
        PatrolState = new DasherPatrolState(this, StateMachine, (DasherData)data, "Move");
        AlertedState = new DasherAlertedState(this, StateMachine, (DasherData)data, "Alerted");
        AgroState = new DasherAgroState(this, StateMachine, (DasherData)data, "Move");
        AttackState = new DasherAttackState(this, StateMachine, (DasherData)data, "Attack");
        CCState = new DasherCCState(this, StateMachine, (DasherData)data, "Idle");
        DeathState = new DasherDeathState(this, StateMachine, (DasherData)data, "Death");
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
