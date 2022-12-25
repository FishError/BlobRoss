using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Description:
// Boss lobs rock throughout the arena randomly each with a radius of 32px,
// leaving indicators through the map indicating where it will land.

public class MortarStrike : BossAttack
{
    private Tako boss;
    private TakoData data;

    private float animationTime;

    private static int MaxMortarStrike;
    private float nextShotTimer;
    private int currentStrike = 0;
    private float spawnRadius = 3f;

    public MortarStrike(Tako boss, TakoData data, Animator animator, string animName) : base(animator, animName)
    {
        this.boss = boss;
        this.data = data;

        MaxMortarStrike = this.data.MaxMortarStrike;
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

        if (currentStrike == MaxMortarStrike && animationTime >= MaxMortarStrike)
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
        GameObject boulderObject = Object.Instantiate(boss.boulder, boss.mortarStrikeOrigin.position, Quaternion.identity);
        Boulder boulder = boulderObject.GetComponent<Boulder>();
        boulder.SetDamage(boss.Attack);
        boulder.SetTrajectory(boss.target, spawnRadius);

        currentStrike++;
    }

}
