using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombDeathState : EnemyDeathState
{
    private Blomb blomb;
    private BlombData data;

    public BlombDeathState(Blomb blomb, FiniteStateMachine stateMachine, BlombData data, string animName) : base(blomb, stateMachine, data, animName) 
    {
        this.blomb = blomb;
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
