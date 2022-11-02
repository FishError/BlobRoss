using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombAgroState : EnemyAgroState
{
    public BlombAgroState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) { }

    public override void Enter()
    {
        base.Enter();
        enemy.Anim.speed = 1.2f;
    }

    public override void Exit()
    {
        base.Exit();
        enemy.Anim.speed = 1f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        float distance = Vector2.Distance(enemy.target.transform.position, enemy.transform.position);
        if (distance <= enemyData.AttackRange)
        {
            stateMachine.ChangeState(enemy.AttackState);
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
            stateMachine.ChangeState(enemy.AttackState);
        }
    }
}
