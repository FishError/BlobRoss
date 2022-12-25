using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseState : BossState
{
    protected Boss boss;
    protected BossData data;

    public BossBaseState(Boss boss, FiniteStateMachine stateMachine, BossData data, Animator animator, string animName) : base(stateMachine, animator, animName)
    {
        this.boss = boss;
        this.data = data;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
        startPosition = boss.transform.position;
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
