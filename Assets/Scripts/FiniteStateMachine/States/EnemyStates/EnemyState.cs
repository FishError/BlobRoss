using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    protected string animName;
    protected float distance;

    public EnemyState(FiniteStateMachine stateMachine, string animName) : base(stateMachine)
    {
        this.animName = animName;
    }

    public override void DoChecks()
    {

    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }
}
