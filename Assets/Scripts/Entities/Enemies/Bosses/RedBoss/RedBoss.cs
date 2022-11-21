using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : Boss
{
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
        AgroState = new BossAgroState(this, StateMachine, (RedBossData)data, "Move/Idle");
        AttackState = new BossAttackState(this, StateMachine, (RedBossData)data);
        DeathState = new BossDeathState(this, StateMachine, (RedBossData)data, "red_boss_death");
    }

    protected override void Start()
    {
        base.Start();

        waitTimeBetweenAttacks = ((RedBossData)data).WaitTimeBetweenAttacksP1;

        Attacks.Add(new MortarStrike(this, (RedBossData)data, Anim, "MortarStrike"));
        Attacks.Add(new Firebolt(this, (RedBossData)data, Anim, "Firebolt"));
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
        Attacks.Add(new BlombSquad(this, (RedBossData)data, Anim, "BlombSquad"));
        Attacks.Add(new WheelOfFlame(this, (RedBossData)data, Anim, "WheelOfFlame"));
    }
}
