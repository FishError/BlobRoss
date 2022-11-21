using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : BossEnemyState
{
    public BossDeathState(RedBoss boss, FiniteStateMachine stateMachine, RedBossData data, string animName) : base(boss, stateMachine, data, animName) { }

    public override void Enter()
    {
        base.Enter();
        boss.SetVelocityX(0f);
        boss.SetVelocityY(0f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Complete animation first and then destory gameobject
        AnimatorStateInfo animState = boss.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName(animName) && animState.normalizedTime >= 1)
        {
            Object.Destroy(boss.gameObject);
        }

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
