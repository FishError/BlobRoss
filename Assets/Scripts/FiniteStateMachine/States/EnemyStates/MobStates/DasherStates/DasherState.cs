using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherState : MobState
{
    protected Dasher dasher;
    protected DasherData data;

    public DasherState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, Animator animator, string animName) : base(stateMachine, animator, animName)
    {
        this.dasher = dasher;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        startPosition = dasher.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        distance = Vector2.Distance(dasher.target.transform.position, dasher.transform.position);
    }
}
