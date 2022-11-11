using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Desciption:
// Boss fires fireballs towards blob in a straight line, flying at speed of 8 and radius of 8px

public class FireBolt : BossAttack
{
    private RedBoss boss;
    private RedBossData data;
    private static int MaxFireball;
    private int currentAmtFireball;
    private Vector2 targetDirection;
    private float nextShotTimer;
    private static float intervalBetweenShots = 0.25f;

    private static float fireballSpeed = 7;
    private static float fireballLifeDistance = 15;

    public FireBolt(RedBoss boss, RedBossData data, string animName) : base(animName)
    {
        this.boss = boss;
        this.data = data;

        MaxFireball = this.data.MaxFireboltAmount;
        DamageRatio = this.data.FireboltDamageRatio;
        Cooldown = this.data.FireboltCooldown;
        Range = this.data.FireboltRange;
    }

    public override void Enter()
    {
        base.Enter();
        nextShotTimer = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        currentAmtFireball = 0;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        targetDirection = (boss.target.transform.position - boss.transform.position).normalized;
        boss.firebolt.transform.localPosition = new Vector2(targetDirection.x, targetDirection.y);

        if (currentAmtFireball == MaxFireball)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Time.time >= nextShotTimer)
        {
            CreateFireball();
            nextShotTimer = Time.time + intervalBetweenShots;
        }
    }

    private void CreateFireball()
    {
        GameObject fireball = Object.Instantiate(boss.fireball, boss.firebolt.transform.position, Quaternion.identity);
        Fireball fb = fireball.GetComponent<Fireball>();
        fb.SetDamage(boss.Attack * DamageRatio);
        fb.SetVelocity(targetDirection, fireballSpeed);
        fb.lifeDistance = fireballLifeDistance;
        currentAmtFireball++;
    }
}
