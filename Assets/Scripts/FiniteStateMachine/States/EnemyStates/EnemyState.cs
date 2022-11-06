using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;
    protected EnemyData enemyData;

    protected string animName;

    public EnemyState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName): base(stateMachine)
    {
        this.enemy = enemy;
        this.enemyData = enemyData;
        this.animName = animName;
    }

    public override void DoChecks()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
        startPosition = enemy.transform.position;
        enemy.Anim.SetBool(animName, true);
    }

    public override void Exit()
    {
        enemy.Anim.SetBool(animName, false);
    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        
    }

    protected void ChangeStateAfterAnimation(string animName, EntityState state)
    {
        AnimatorStateInfo animState = enemy.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName(animName) && animState.normalizedTime >= 1)
        {
            stateMachine.ChangeState(state);
            return;
        }
    }
}
