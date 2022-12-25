using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBaseDeathState : MobBaseState
{
    public MobBaseDeathState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, Animator animator, string animName) : base(enemy, stateMachine, data, animator, animName) { }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0f);
        enemy.SetVelocityY(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Complete animation first and then destory gameobject
        AnimatorStateInfo animState = enemy.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName(animName) && animState.normalizedTime >= 1)
        {
            Object.Destroy(enemy.gameObject);

            if (enemy.lootDrop != null)
                Object.Instantiate(enemy.lootDrop, enemy.transform.position, Quaternion.identity);
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
