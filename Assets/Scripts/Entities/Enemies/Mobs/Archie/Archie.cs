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

        SpawnState = new MobBaseSpawnState(this, StateMachine, Data, Anim, "Idle");
        IdleState = new MobBaseIdleState(this, StateMachine, Data, Anim, "Idle");
        PatrolState = new MobBasePatrolState(this, StateMachine, Data, Anim, "Move");
        AlertedState = new MobBaseAlertedState(this, StateMachine, Data, Anim, "Alerted");
        CCState = new MobBaseCCState(this, StateMachine, Data, Anim, "Idle");
        DeathState = new MobBaseDeathState(this, StateMachine, Data, Anim, "Death");

        AgroState = new ArchieAgroState(this, StateMachine, Data, Anim, "Move");
        AttackState = new ArchieAttackState(this, StateMachine, Data, Anim, "Attack", arrow, spawnPosition);
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
