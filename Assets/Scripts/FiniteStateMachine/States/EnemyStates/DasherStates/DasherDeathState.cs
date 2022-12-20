using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherDeathState : DasherState
{
    public DasherDeathState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) { }

    public override void Enter()
    {
        base.Enter();
        dasher.SetVelocityX(0f);
        dasher.SetVelocityY(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Complete animation first and then destory gameobject
        AnimatorStateInfo animState = dasher.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName(animName) && animState.normalizedTime >= 1)
        {
            Object.Destroy(dasher.gameObject);

            if (dasher.lootDrop != null)
                Object.Instantiate(dasher.lootDrop, dasher.transform.position, Quaternion.identity);
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
