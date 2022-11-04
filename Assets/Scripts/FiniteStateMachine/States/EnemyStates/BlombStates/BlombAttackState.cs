using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombAttackState : EnemyAttackState
{
    public BlombAttackState(Blomb enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) { }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
        Object.Instantiate(((Blomb)enemy).fieldOnDeath, enemy.transform.position, Quaternion.identity);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        AnimationHasFinish(enemy.DeathState);
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
