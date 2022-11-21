using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombAttackState : EnemyAttackState
{
    private Blomb blomb;
    private BlombData data;

    public BlombAttackState(Blomb blomb, FiniteStateMachine stateMachine, BlombData data, string animName) : base(blomb, stateMachine, data, animName) 
    {
        this.blomb = blomb;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        blomb.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        AnimatorStateInfo animState = blomb.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName(animName) && animState.normalizedTime >= 1)
        {
            Object.Instantiate(blomb.fieldOnDeath, blomb.transform.position, Quaternion.identity);
            Object.Destroy(blomb.gameObject);
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
