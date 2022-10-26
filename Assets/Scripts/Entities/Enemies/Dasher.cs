using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : Enemy
{
    #region States
    
    #endregion

    protected override void Awake()
    {
        base.Awake();
        IdleState = new DasherIdleState(this, StateMachine, enemyData, "Idle");
        PatrolState = new DasherPatrolState(this, StateMachine, enemyData, "Move");
        AlertedState = new DasherAlertedState(this, StateMachine, enemyData, "Alerted");
        AgroState = new DasherAgroState(this, StateMachine, enemyData, "Move");
        AttackState = new DasherAttackState(this, StateMachine, enemyData, "Attack");
        CCState = new DasherCCState(this, StateMachine, enemyData, "Idle");
        DeathState = new DasherDeathState(this, StateMachine, enemyData, "Death");
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
