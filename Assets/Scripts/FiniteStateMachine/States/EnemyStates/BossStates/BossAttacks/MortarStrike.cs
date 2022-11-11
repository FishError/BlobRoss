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
    private static int MaxMortarStrike;
    private float nextShotTimer;
    private static float intervalBetweenShots = 1f;
    private int currentStrike = 0;
    private float spawnRadius = 3f;

    public MortarStrike(RedBoss boss, RedBossData data, string animName) : base(animName)
    {
        this.boss = boss;
        this.data = data;

        MaxMortarStrike = this.data.MaxMortarStrike;
        DamageRatio = this.data.MortarStrikeDamageRatio;
        Range = this.data.MortarStrikeRange;
        Cooldown = this.data.MortarStrikeCooldown;
    }

    public override void Enter()
    {
        base.Enter();
        nextShotTimer = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        currentStrike = 0;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (currentStrike == MaxMortarStrike)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Time.time >= nextShotTimer)
        {
            SummonBoulder();
            nextShotTimer = Time.time + intervalBetweenShots;
        }
    }

    private void SummonBoulder()
    {
        Vector2 randomPos = (Vector2)boss.target.transform.position + Random.insideUnitCircle * spawnRadius;
        GameObject boulderObject = Object.Instantiate(boss.boulder, new Vector2(randomPos.x, randomPos.y + 20), Quaternion.identity);
        GameObject indicator = Object.Instantiate(boss.boulderIndicator, new Vector2(randomPos.x, randomPos.y - 1f), Quaternion.identity);

        Boulder boulder = boulderObject.GetComponent<Boulder>();
        boulder.SetDamage(boss.Attack * DamageRatio);
        boulder.SetYPosition(randomPos.y);
        boulder.SetIndicator(indicator);
        boulder.SetVelocity(Vector2.down, 20f);
        currentStrike++;
    }

}
