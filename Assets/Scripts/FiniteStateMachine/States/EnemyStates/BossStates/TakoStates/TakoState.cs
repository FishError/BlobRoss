using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoState : BossState
{
    protected Tako boss;
    protected TakoData data;

    public TakoState(Tako boss, FiniteStateMachine stateMachine, TakoData data, string animName) : base(stateMachine, animName)
    {
        this.boss = boss;
        this.data = data;
    }

    public override void DoChecks()
    {

    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
        startPosition = boss.transform.position;
        boss.Anim.SetBool(animName, true);
    }

    public override void Exit()
    {
        boss.Anim.SetBool(animName, false);
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }
}
