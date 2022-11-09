using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Description:
// Spawns 10 bomb blobs in random areas around the arena

public class SummonBlombs : BossAttack
{
    private RedBoss boss;
    private RedBossData data;

    public SummonBlombs(RedBoss boss, RedBossData data, string animName) : base(animName)
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
