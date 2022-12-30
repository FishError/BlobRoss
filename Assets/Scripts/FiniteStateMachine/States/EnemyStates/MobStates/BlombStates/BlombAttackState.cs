using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombAttackState : BlombState
{

    public BlombAttackState(Blomb blomb, FiniteStateMachine stateMachine, BlombData data, Animator animator, string animName) : base(blomb, stateMachine, data, animator, animName) 
    {
        this.blomb = blomb;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        blomb.rb.velocity = Vector2.zero;
        blomb.AttackState.PlayEnemyAudio(blomb, blomb.gameObject, 2, 0f, true);
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
            GameObject fireField = Object.Instantiate(blomb.fieldOnDeath, blomb.transform.position, Quaternion.identity);
            blomb.AttackState.PlayEnemyAudio(blomb, fireField.gameObject, 3, 0f, false);
            Object.Destroy(blomb.gameObject);

            if (blomb.lootDrop != null)
                Object.Instantiate(blomb.lootDrop, blomb.transform.position, Quaternion.identity);
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
