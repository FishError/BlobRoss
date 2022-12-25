using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Description:
// Spawns 10 bomb blobs in random areas around the arena

public class BlombSquad : BossAttack
{
    private Tako boss;
    private TakoData data;

    private static int maxBlombSummons;
    private int blombCount;

    private static float intervalBetweenSummons = 0.3f;
    private float summonTimer;

    public BlombSquad(Tako boss, TakoData data, Animator animator, string animName) : base(animator, animName)
    {
        this.boss = boss;
        this.data = data;

        maxBlombSummons = this.data.MaxBlombSummons;
        Range = this.data.BlombSquadRange;
        Cooldown = this.data.BlombSquadCooldown;
    }

    public override void Enter()
    {
        base.Enter();
        summonTimer = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        blombCount = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (blombCount == maxBlombSummons)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }

        if (Time.time >= summonTimer)
        {
            InstantiateBlomb();

            blombCount++;
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
