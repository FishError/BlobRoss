using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombState : MobState
{
    protected Blomb blomb;
    protected BlombData data;

    public BlombState(Blomb blomb, FiniteStateMachine stateMachine, BlombData data, string animName) : base(stateMachine, animName)
    {
        this.blomb = blomb;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        startPosition = blomb.transform.position;
        blomb.Anim.SetBool(animName, true);
    }

    public override void Exit()
    {
        base.Exit();
        blomb.Anim.SetBool(animName, false);
    }

    public override void LogicUpdate()
    {
        distance = Vector2.Distance(blomb.target.transform.position, blomb.transform.position);
    }
}
