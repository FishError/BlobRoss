using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Description:
// Spawns 10 bomb blobs in random areas around the arena

public class BlombSquad : BossAttack
{
    private RedBoss boss;
    private RedBossData data;

    private static int maxNumOfBlombs = 10;
    private int numOfSummonedBlombs;

    private static float intervalBetweenSummons = 0.3f;
    private float summonTimer;

    public BlombSquad(RedBoss boss, RedBossData data, string animName) : base(animName)
    {
        this.boss = boss;
        this.data = data;

        Range = this.data.SummonBlombsRange;
        Cooldown = this.data.SummonBlombsCooldown;
    }

    public override void Enter()
    {
        base.Enter();
        summonTimer = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        numOfSummonedBlombs = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (numOfSummonedBlombs == maxNumOfBlombs)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }

        if (Time.time >= summonTimer)
        {
            InstantiateBlomb();

            numOfSummonedBlombs++;
            summonTimer = Time.time + intervalBetweenSummons;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void InstantiateBlomb()
    {
        Vector2 spawnCenter = boss.BlombSpawnArea.position;
        float spawnRadius = boss.BlombSpawnArea.GetComponent<CircleCollider2D>().radius;
        Vector2 randomPos = spawnCenter + Random.insideUnitCircle * spawnRadius;
        GameObject blomb = Object.Instantiate(boss.Blomb, randomPos, Quaternion.identity);
        Blomb b = blomb.GetComponent<Blomb>();
        b.target = boss.target;
    }
}
