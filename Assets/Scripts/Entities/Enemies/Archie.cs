using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archie : Enemy
{
    [SerializeField] protected GameObject arrow;
    [SerializeField] protected Transform spawnPosition;

    protected override void Awake()
    {
        base.Awake();
        IdleState = new ArchieIdleState(this, StateMachine, (EnemyData)data, "Idle");
        PatrolState = new ArchiePatrolState(this, StateMachine, (EnemyData)data, "Move");
        AlertedState = new ArchieAlertedState(this, StateMachine, (EnemyData)data, "Alerted");
        AgroState = new ArchieAgroState(this, StateMachine, (EnemyData)data, "Move");
        AttackState = new ArchieAttackState(this, StateMachine, (EnemyData)data, "Attack", arrow, spawnPosition);
        CCState = new ArchieCCState(this, StateMachine, (EnemyData)data, "Idle");
        DeathState = new ArchieDeathState(this, StateMachine, (EnemyData)data, "Death");
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
