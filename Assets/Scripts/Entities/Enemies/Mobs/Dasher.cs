using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : MobEnemy
{
    /*#region States 
    // base states that all children are required to have but dont always have use
    // children may also have more than just these states
    public DasherIdleState IdleState { get; protected set; }
    public DasherPatrolState PatrolState { get; protected set; }
    public DasherAlertedState AlertedState { get; protected set; }
    public DasherAgroState AgroState { get; protected set; }
    public DasherAttackState AttackState { get; protected set; }
    public DasherCCState CCState { get; protected set; }
    public DasherDeathState DeathState { get; protected set; }
    #endregion*/

    public DasherData Data { get; protected set; }

    public float DashDamageRatio { get; set; }
    public float DashSpeedRatio { get; set; }
    public float KnockbackForce { get; set; }
    public float KnockbackDuration { get; set; }

    protected override void Awake()
    {
        base.Awake();
        Data = (DasherData)data;

        IdleState = new DasherIdleState(this, StateMachine, Data, "Idle");
        PatrolState = new DasherPatrolState(this, StateMachine, Data, "Move");
        AlertedState = new DasherAlertedState(this, StateMachine, Data, "Alerted");
        AgroState = new DasherAgroState(this, StateMachine, Data, "Move");
        AttackState = new DasherAttackState(this, StateMachine, Data, "Attack");
        CCState = new DasherCCState(this, StateMachine, Data, "Idle");
        DeathState = new DasherDeathState(this, StateMachine, Data, "Death");
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
