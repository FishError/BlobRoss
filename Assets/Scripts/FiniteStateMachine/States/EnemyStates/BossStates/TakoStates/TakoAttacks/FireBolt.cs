using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Desciption:
// Boss fires fireballs towards blob in a straight line, flying at speed of 8 and radius of 8px

public class Firebolt : BossAttack
{
    private Tako boss;
    private TakoData data;

    private float animationTime;

    private static int MaxFireball;
    private int currentAmtFireball;
    private Vector2 targetDirection;
    private float nextShotTimer;

    public Firebolt(Tako boss, TakoData data, Animator animator, string animName) : base(animator, animName)
    {
        this.boss = boss;
        this.data = data;

        MaxFireball = this.data.MaxFireboltAmount;
        Cooldown = this.data.FireboltCooldown;
        Range = this.data.FireboltRange;
    }

    public override void Enter()
    {
        base.Enter();
        animationTime = 0;
        nextShotTimer = 2/4; // frame number to create boulder divided by total frames
        targetDirection = (boss.target.transform.position - boss.transform.position).normalized;
    }

    public override void Exit()
    {
        base.Exit();
        currentAmtFireball = 0;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (boss.Anim.GetCurrentAnimatorStateInfo(0).IsName(animName))
            animationTime = boss.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

        targetDirection = (boss.target.transform.position - boss.transform.position).normalized;
        boss.lookAt = targetDirection;
        boss.SetAnimHorizontalVertical(boss.lookAt);

        if (currentAmtFireball == MaxFireball && animationTime >= MaxFireball)
        {
            boss.StateMachine.ChangeState(boss.AgroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (animationTime >= nextShotTimer)
        {
            CreateFireball();
            nextShotTimer++;
        }
    }

    private void CreateFireball()
    {
        Vector3 spawnPos = GetFireballSpawnPosition();
        GameObject fireball = Object.Instantiate(boss.fireball, spawnPos, Quaternion.identity);
        Fireball fb = fireball.GetComponent<Fireball>();
        fb.PlayOnSpecificVolume(0.8f);
        fb.SetDamage(boss.Attack);
        fb.SetVelocity((boss.target.transform.position - spawnPos).normalized);
        currentAmtFireball++;
    }

    private Vector3 GetFireballSpawnPosition()
    {
        Transform spawnPos = null;
        Vector2 dir = CalculateDirection(targetDirection);
        if (dir == Vector2.left)
        {
            spawnPos = boss.fireboltOrigins.transform.Find("Left");
        }
        else if (dir == Vector2.right)
        {
            spawnPos = boss.fireboltOrigins.transform.Find("Right");
        }
        else if (dir == Vector2.down)
        {
            spawnPos = boss.fireboltOrigins.transform.Find("Down");
        }
        else if (dir == Vector2.up)
        {
            spawnPos = boss.fireboltOrigins.transform.Find("Up");
        }

        if (spawnPos == null)
            return Vector3.zero;
        return spawnPos.position;
    }

    private static Vector2 CalculateDirection(Vector2 v)
    {
        Vector2[] directions = new Vector2[] { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
        float maxDot = -Mathf.Infinity;
        Vector2 closestDir = Vector2.zero;

        foreach (Vector2 dir in directions)
        {
            float t = Vector2.Dot(v, dir);
            if (t > maxDot)
            {
                closestDir = dir;
                maxDot = t;
            }
        }

        return closestDir;
    }
}
