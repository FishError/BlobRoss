using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : Boss
{
    protected override void Awake()
    {
        base.Awake();
        AgroState = new BossAgroState(this, StateMachine, (RedBossData)data, "");
        AttackState = new BossAttackState(this, StateMachine, (RedBossData)data, "");
    }

    protected override void Start()
    {
        base.Start();
        Attacks.Add(new MortarStrike(this, (RedBossData)data, ""));
        Attacks.Add(new FireBall(this, (RedBossData)data, ""));
        Attacks.Add(new SummonBlombs(this, (RedBossData)data, ""));
        Attacks.Add(new FireBallBulletHell(this, (RedBossData)data, ""));
    }
}
