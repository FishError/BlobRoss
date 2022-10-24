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
        IdleState = new DasherIdleState(this, StateMachine, enemyData);
        PatrolState = new DasherPatrolState(this, StateMachine, enemyData);
        AlertedState = new DasherAlertedState(this, StateMachine, enemyData);
        AgroState = new DasherAgroState(this, StateMachine, enemyData);
        AttackState = new DasherAttackState(this, StateMachine, enemyData);
        CCState = new DasherCCState(this, StateMachine, enemyData);
        DeathState = new DasherDeathState(this, StateMachine, enemyData);
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
