using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombAgroState : EnemyAgroState
{
    private Blomb blomb;
    private BlombData data;

    public BlombAgroState(Blomb blomb, FiniteStateMachine stateMachine, BlombData data, string animName) : base(blomb, stateMachine, data, animName) 
    {
        this.blomb = blomb;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        blomb.Anim.speed = 1.2f;
    }

    public override void Exit()
    {
        base.Exit();
        blomb.Anim.speed = 1f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (distance <= data.AttackRange)
        {
            stateMachine.ChangeState(blomb.AttackState);
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

    public override void OnCollisionEnter(Collision2D collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "Player")
        {
            stateMachine.ChangeState(blomb.AttackState);
        }
    }
}
