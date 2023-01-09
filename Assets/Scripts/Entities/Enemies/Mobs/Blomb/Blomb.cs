using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blomb : Mob
{
    public BlombData Data { get; protected set; }

    public GameObject fieldOnDeath;
    public float ExplosionDamageRatio { get; set; }
    public float KnockbackForce { get; set; }
    public float KnockbackDuration { get; set; }

    protected override void Awake()
    {
        base.Awake();
        Data = (BlombData)data;

        SpawnState = new MobBaseSpawnState(this, StateMachine, Data, Anim, "Idle");
        IdleState = new MobBaseIdleState(this, StateMachine, Data, Anim, "Idle");
        PatrolState = new MobBasePatrolState(this, StateMachine, Data, Anim, "Move");
        AlertedState = new MobBaseAlertedState(this, StateMachine, Data, Anim, "Idle");
        CCState = new MobBaseCCState(this, StateMachine, Data, Anim, "Idle");
        DeathState = new MobBaseDeathState(this, StateMachine, Data, Anim, "Death");

        AgroState = new BlombAgroState(this, StateMachine, Data, Anim, "Move");
        AttackState = new BlombAttackState(this, StateMachine, Data, Anim, "Attack");
    }

    protected override void Start()
    {
        base.Start();

        ExplosionDamageRatio = Data.ExplosionDamageRatio;
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
