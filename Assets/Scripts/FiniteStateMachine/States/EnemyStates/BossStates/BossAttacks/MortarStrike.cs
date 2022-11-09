using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Description:
// Boss lobs rock throughout the arena randomly each with a radius of 32px,
// leaving indicators through the map indicating where it will land.

public class MortarStrike : BossAttack
{
    private RedBoss boss;
    private RedBossData data;

    public MortarStrike(RedBoss boss, RedBossData data, string animName) : base(animName)
    {
        this.boss = boss;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
