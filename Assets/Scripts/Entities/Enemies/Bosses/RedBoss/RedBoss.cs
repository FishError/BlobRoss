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
        AgroState = new BossAgroState(this, StateMachine, (RedBossData)data, "");
        AttackState = new BossAttackState(this, StateMachine, (RedBossData)data, "");
    }

    protected override void Start()
    {
        base.Start();

        waitTimeBetweenAttacks = ((RedBossData)data).WaitTimeBetweenAttacksP1;

        Attacks.Add(new MortarStrike(this, (RedBossData)data, ""));
        Attacks.Add(new FireBolt(this, (RedBossData)data, ""));
        Attacks.Add(new BlombSquad(this, (RedBossData)data, ""));
        Attacks.Add(new WheelOfFire(this, (RedBossData)data, ""));
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
}
