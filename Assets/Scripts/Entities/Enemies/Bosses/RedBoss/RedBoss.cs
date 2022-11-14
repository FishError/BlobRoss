using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : Boss
{
    public GameObject Blomb;
    public Transform BlombSpawnArea;

    public GameObject fireball, boulder, boulderIndicator;
    public Transform WheelOfFire, firebolt;

    protected override void Awake()
    {
        base.Awake();
        AgroState = new BossAgroState(this, StateMachine, (RedBossData)data, "Move/Idle");
        AttackState = new BossAttackState(this, StateMachine, (RedBossData)data);
    }

    protected override void Start()
    {
        base.Start();

        waitTimeBetweenAttacks = ((RedBossData)data).WaitTimeBetweenAttacksP1;

        //Attacks.Add(new MortarStrike(this, (RedBossData)data, Anim, "MortarStrike"));
        Attacks.Add(new Firebolt(this, (RedBossData)data, Anim, "Firebolt"));
        //Attacks.Add(new BlombSquad(this, (RedBossData)data, Anim, "BlombSquad"));
        //Attacks.Add(new WheelOfFlame(this, (RedBossData)data, Anim, "WheelOfFlame"));
    }

    protected override void Update()
    {
        base.Update();

        if (phase == 1 && HealthPoints < MaxHealthPoints / 2)
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
