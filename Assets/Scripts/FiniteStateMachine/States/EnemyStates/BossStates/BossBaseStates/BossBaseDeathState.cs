using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseDeathState : BossBaseState
{
    public BossBaseDeathState(Boss boss, FiniteStateMachine stateMachine, BossData data, Animator animator, string animName) : base(boss, stateMachine, data, animator, animName) { }

    public override void Enter()
    {
        base.Enter();
        boss.SetVelocityX(0f);
        boss.SetVelocityY(0f);
        boss.isDeathStateCalled = true;
        SFXManager.Instance.PlayEnemyRelatedAudio(boss, boss.gameObject, 0, 0f, false);
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
