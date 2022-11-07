using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherAgroState : EnemyAgroState
{
    private Dasher dasher;
    private DasherData data;

    public DasherAgroState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) 
    {
        this.dasher = dasher;
        this.data = data;
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

        if (distance <= base.enemyData.AttackRange && dasher.AttackCoolDown <= 0)
        {
            stateMachine.ChangeState(dasher.AttackState);
            return;
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
