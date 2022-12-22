using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archie : Mob
{
    public ArchieData Data { get; protected set; }

    [SerializeField] protected GameObject arrow;
    [SerializeField] protected Transform spawnPosition;

    public float ArcherDamageRatio { get; set; }
    public float ArcherSpeedRatio { get; set; }
    public float ProjectileSpeed { get; set; }
    public float DestroyTime { get; set; }
    protected override void Awake()
    {
        base.Awake();
        Data = (ArchieData)data;

        IdleState = new MobBaseIdleState(this, StateMachine, Data, "Idle");
        PatrolState = new MobBasePatrolState(this, StateMachine, Data, "Move");
        AlertedState = new MobBaseAlertedState(this, StateMachine, Data, "Alerted");
        CCState = new MobBaseCCState(this, StateMachine, Data, "Idle");
        DeathState = new MobBaseDeathState(this, StateMachine, Data, "Death");

        AgroState = new ArchieAgroState(this, StateMachine, Data, "Move");
        AttackState = new ArchieAttackState(this, StateMachine, Data, "Attack", arrow, spawnPosition);
    }

    protected override void Start()
    {
        base.Start();

        ArcherDamageRatio = Data.ArcherDamageRatio;
        ArcherSpeedRatio = Data.ArcherSpeedRatio;
        ProjectileSpeed = Data.ProjectileSpeed;
        DestroyTime = Data.DestroyTime;
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
