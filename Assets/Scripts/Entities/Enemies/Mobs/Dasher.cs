using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : Mob
{
    public DasherData Data { get; protected set; }

    public float DashDamageRatio { get; set; }
    public float DashSpeedRatio { get; set; }
    public float KnockbackForce { get; set; }
    public float KnockbackDuration { get; set; }

    protected override void Awake()
    {
        base.Awake();
        Data = (DasherData)data;

        IdleState = new MobBaseIdleState(this, StateMachine, Data, Anim, "Idle");
        PatrolState = new MobBasePatrolState(this, StateMachine, Data, Anim, "Move");
        AlertedState = new MobBaseAlertedState(this, StateMachine, Data, Anim, "Alerted");
        CCState = new MobBaseCCState(this, StateMachine, Data, Anim, "Idle");
        DeathState = new MobBaseDeathState(this, StateMachine, Data, Anim, "Death");

        AgroState = new DasherAgroState(this, StateMachine, Data, Anim, "Move");
        AttackState = new DasherAttackState(this, StateMachine, Data, Anim, "Attack");
    }

    protected override void Start()
    {
        base.Start();

        DashDamageRatio = Data.DashDamageRatio;
        DashSpeedRatio = Data.DashSpeedRatio;
        KnockbackForce = Data.KnockbackForce;
        KnockbackDuration = Data.KnockbackDuration;
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
