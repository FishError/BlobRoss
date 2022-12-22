using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseIdleState : BossBaseState
{
    public BossBaseIdleState(Boss boss, FiniteStateMachine stateMachine, BossData data, string animName) : base(boss, stateMachine, data, animName)
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
        float dis = Vector2.Distance(boss.transform.position, boss.target.transform.position);
        if (dis < 10)
            stateMachine.ChangeState(boss.AgroState);
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
