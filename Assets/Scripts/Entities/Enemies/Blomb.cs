using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blomb : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        IdleState = new BlombIdleState(this, StateMachine, (EnemyData)data, "Idle");
        PatrolState = new BlombPatrolState(this, StateMachine, (EnemyData)data, "Move");
        AlertedState = new BlombAlertedState(this, StateMachine, (EnemyData)data, "Idle");
        AgroState = new BlombAgroState(this, StateMachine, (EnemyData)data, "Move");
        AttackState = new BlombAttackState(this, StateMachine, (EnemyData)data, "Attack");
        CCState = new EnemyCCState(this, StateMachine, (EnemyData)data, "Idle");
        DeathState = new EnemyDeathState(this, StateMachine, (EnemyData)data, "Death");
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
