using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Description:
// Boss fires balls of molten rock outward in a straight line in a circular
// arrangement 5 times with the balls shifting slightly in between each fire

public class WheelOfFire : BossAttack
{
    private RedBoss boss;
    private RedBossData data;

    private float nextShotTimer;
    private static float intervalBetweenShots = 0.5f;

    private static int maxNumOfShots = 10;
    private int currentNumOfShots = 0;

    private float rotationAmount = 20f;

    public WheelOfFire(RedBoss boss, RedBossData data, string animName) : base(animName)
    {
        this.boss = boss;
        this.data = data;

        DamageRatio = this.data.FireBallBulletHellDamageRatio;
        Range = this.data.FireBallBulletHellRange;
        Cooldown = this.data.FireBallBulletHellCooldown;
    }

    public override void Enter()
    {
        base.Enter();
        nextShotTimer = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        currentNumOfShots = 0;
        boss.FireBallBulletHell.transform.rotation = Quaternion.identity;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (currentNumOfShots == maxNumOfShots)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Time.time >= nextShotTimer)
        {
            foreach(Transform t in boss.FireBallBulletHell)
            {
                CreateFireball(t.position);
            }
            currentNumOfShots++;

            nextShotTimer = Time.time + intervalBetweenShots;
            boss.FireBallBulletHell.transform.Rotate(0, 0, rotationAmount);
        }
    }

    private void CreateFireball(Vector2 spawnPosition)
    {
        GameObject fireball = Object.Instantiate(boss.fireball, spawnPosition, Quaternion.identity);
        Fireball fb = fireball.GetComponent<Fireball>();
        Vector2 dir = ((Vector3)spawnPosition - boss.transform.position).normalized;
        fb.SetVelocity(dir, 7);
        fb.lifeDistance = 15;
    }
}
