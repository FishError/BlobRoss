using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : Enemy
{
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
