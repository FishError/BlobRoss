using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tako : Boss
{
    public TakoData Data { get; set; }

    [Header("Blomb Squad")]
    public GameObject Blomb;
    public Transform BlombSpawnArea;

    [Header("Firebolt")]
    public GameObject fireball;
    public Transform fireboltOrigins;

    [Header("Mortar Strike")]
    public GameObject boulder;
    public Transform mortarStrikeOrigin;

    [Header("Wheel of Flame")]
    public Transform WheelOfFireOrigins;

    protected override void Awake()
    {
        base.Awake();
        Data = (TakoData)data;

        IdleState = new BossBaseIdleState(this, StateMachine, Data, "Move/Idle");
        AgroState = new BossBaseAgroState(this, StateMachine, Data, "Move/Idle");
        AttackState = new BossBaseAttackState(this, StateMachine, Data);
        DeathState = new BossBaseDeathState(this, StateMachine, Data, "red_boss_death");
    }

    protected override void Start()
    {
        base.Start();

        waitTimeBetweenAttacks = Data.WaitTimeBetweenAttacksP1;

        Attacks.Add(new MortarStrike(this, Data, Anim, "MortarStrike"));
        Attacks.Add(new Firebolt(this, Data, Anim, "Firebolt"));
    }

    protected override void Update()
    {
        base.Update();

        if (phase == 1 && HealthPoints <= MaxHealthPoints / 2)
        {
            phase = 2;
            UpdateStatsPhase2();
        }
    }

    protected override void UpdateStatsPhase2()
    {
        base.UpdateStatsPhase2();
        Attacks.Add(new BlombSquad(this, Data, Anim, "BlombSquad"));
        Attacks.Add(new WheelOfFlame(this, Data, Anim, "WheelOfFlame"));
    }
}
