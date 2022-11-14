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

    private float animationTime;

    private static int MaxMortarStrike;
    private float nextShotTimer;
    private static float intervalBetweenShots = 1f;
    private int currentStrike = 0;
    private float spawnRadius = 3f;

    public MortarStrike(RedBoss boss, RedBossData data, Animator animator, string animName) : base(animator, animName)
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
        animationTime = 0;
        nextShotTimer = 3/4; // frame number to create boulder divided by total frames
    }

    public override void Exit()
    {
        base.Exit();
        currentStrike = 0;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (boss.Anim.GetCurrentAnimatorStateInfo(0).IsName(animName))
            animationTime = boss.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (currentStrike == MaxMortarStrike)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (animationTime >= nextShotTimer)
        {
            SummonBoulder();
            nextShotTimer++;
        }


    }

    private void SummonBoulder()
    {
        Vector2 randomPos = (Vector2)boss.target.transform.position + Random.insideUnitCircle * spawnRadius;
        GameObject boulderObject = Object.Instantiate(boss.boulder, new Vector2(randomPos.x, randomPos.y + 20), Quaternion.identity);
        GameObject indicator = Object.Instantiate(boss.boulderIndicator, new Vector2(randomPos.x, randomPos.y - 1f), Quaternion.identity);

        Boulder boulder = boulderObject.GetComponent<Boulder>();
        boulder.SetYPosition(randomPos.y);
        boulder.SetIndicator(indicator);
        boulder.SetVelocity(Vector2.down, 20f);

        AreaOfEffectIndicator aoeIndicator = indicator.GetComponent<AreaOfEffectIndicator>();
        aoeIndicator.damage = boss.Attack * DamageRatio;
        aoeIndicator.effectTriggerTime = 1f;

        currentStrike++;
    }

}
