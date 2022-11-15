using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Description:
// Boss fires balls of molten rock outward in a straight line in a circular
// arrangement 5 times with the balls shifting slightly in between each fire

public class WheelOfFlame : BossAttack
{
    private RedBoss boss;
    private RedBossData data;

    private float nextWaveTimer;
    private static float intervalBetweenWaves = 0.5f;
    private int maxWaveAmount;
    private int currentNumOfShots = 0;
    private float rotationAmount;

    private static float fireballSpeed = 7;
    private static float fireballLifeDistance = 15;

    public WheelOfFlame(RedBoss boss, RedBossData data, Animator animator, string animName) : base(animator, animName)
    {
        this.boss = boss;
        this.data = data;

        maxWaveAmount = this.data.MaxWaveAmount;
        rotationAmount = this.data.RotationBetweenWaves;
        DamageRatio = this.data.WheelOfFireDamageRatio;
        Range = this.data.WheelOfFireHellRange;
        Cooldown = this.data.WheelOfFireCooldown;
    }

    public override void Enter()
    {
        base.Enter();
        nextWaveTimer = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        currentNumOfShots = 0;
        boss.WheelOfFireOrigins.transform.rotation = Quaternion.identity;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (currentNumOfShots == maxWaveAmount)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Time.time >= nextWaveTimer)
        {
            foreach(Transform t in boss.WheelOfFireOrigins)
            {
                CreateFireball(t.position);
            }
            currentNumOfShots++;

            nextWaveTimer = Time.time + intervalBetweenWaves;
            boss.WheelOfFireOrigins.transform.Rotate(0, 0, rotationAmount);
        }
    }

    private void CreateFireball(Vector2 spawnPosition)
    {
        GameObject fireball = Object.Instantiate(boss.fireball, spawnPosition, Quaternion.identity);
        Fireball fb = fireball.GetComponent<Fireball>();
        Vector2 dir = ((Vector3)spawnPosition - boss.transform.position).normalized;
        fb.SetDamage(boss.Attack * DamageRatio);
        fb.SetVelocity(dir, fireballSpeed);
        fb.lifeDistance = fireballLifeDistance;
    }
}
