using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Desciption:
// Boss fires fireballs towards blob in a straight line, flying at speed of 8 and radius of 8px

public class FireBall : BossAttack
{
    public FireBall(RedBoss boss, RedBossData data, string animName) : base(boss, data, animName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
