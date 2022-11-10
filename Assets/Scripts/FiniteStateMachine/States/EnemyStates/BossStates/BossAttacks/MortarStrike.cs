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
    private static float intervalBetweenShots = 0.5f;
    private int currentStrike = 0;

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
            CreateBoulder();
            nextShotTimer = Time.time + intervalBetweenShots;
        }
    }

    private void CreateBoulder()
    {
        //TODO: find area of where boulder can land randomly
        //GameObject boulder = Object.Instantiate(boss.boulder, spawnPosition, Quaternion.identity);
        //Boulder rock = boulder.GetComponent<Boulder>();
        //Vector2 dir = ((Vector3)spawnPosition - boss.transform.position).normalized;
        //fb.SetVelocity(dir, 7);
        //fb.lifeDistance = 15;
        currentStrike++;
    }
}
