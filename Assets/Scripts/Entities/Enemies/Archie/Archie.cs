using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archie : Enemy
{
    [SerializeField] protected GameObject arrow;
    [SerializeField] protected Transform spawnPosition;

    public float ArcherDamageRatio { get; set; }
    public float ArcherSpeedRatio { get; set; }
    public float ProjectileSpeed { get; set; }
    public float DestroyTime { get; set; }
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
        ArcherDamageRatio = ((ArchieData)data).ArcherDamageRatio;
        ArcherSpeedRatio = ((ArchieData)data).ArcherSpeedRatio;
        ProjectileSpeed = ((ArchieData)data).ProjectileSpeed;
        DestroyTime = ((ArchieData)data).DestroyTime;
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
