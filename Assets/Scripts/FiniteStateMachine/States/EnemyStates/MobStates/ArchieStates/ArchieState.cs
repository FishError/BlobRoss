using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieState : MobState
{
    protected Archie archie;
    protected ArchieData data;

    protected Vector2 targetDirection;

    public ArchieState(Archie archie, FiniteStateMachine stateMachine, ArchieData data, string animName) : base(stateMachine, animName)
    {
        this.archie = archie;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        startPosition = archie.transform.position;
        targetDirection = (archie.target.transform.position - archie.transform.position).normalized;
        archie.Anim.SetBool(animName, true);
    }

    public override void Exit()
    {
        base.Exit();
        archie.Anim.SetBool(animName, false);
    }

    public override void LogicUpdate()
    {
        distance = Vector2.Distance(archie.target.transform.position, archie.transform.position);
        targetDirection = (archie.target.transform.position - archie.transform.position).normalized;
    }
}
