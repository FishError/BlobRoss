using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoState : BossState
{
    protected Tako boss;
    protected TakoData data;

    public TakoState(Tako boss, FiniteStateMachine stateMachine, TakoData data, Animator animator, string animName) : base(stateMachine, animator, animName)
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
