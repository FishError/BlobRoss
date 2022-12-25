using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombState : MobState
{
    protected Blomb blomb;
    protected BlombData data;

    public BlombState(Blomb blomb, FiniteStateMachine stateMachine, BlombData data, Animator animator, string animName) : base(stateMachine, animator, animName)
    {
        this.blomb = blomb;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        startPosition = blomb.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        distance = Vector2.Distance(blomb.target.transform.position, blomb.transform.position);
    }
}
