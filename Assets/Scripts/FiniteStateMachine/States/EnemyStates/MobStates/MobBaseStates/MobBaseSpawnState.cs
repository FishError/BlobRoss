using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBaseSpawnState : MobBaseState
{
    private UnityEngine.Color color;
    private float duration = 1;

    public MobBaseSpawnState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, Animator animator, string animName) : base(enemy, stateMachine, data, animator, animName) { }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        color = enemy.Renderer.color;
        color.a = 0;
        enemy.Renderer.color = color;
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (enemy.Renderer.color.a < 1)
        {
            color.a = (Time.time - startTime) / duration;
            enemy.Renderer.color = color;
        }
        else
        {
            stateMachine.ChangeState(enemy.AlertedState);
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
