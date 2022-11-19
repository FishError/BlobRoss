using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobEnemyState : EnemyState
{
    protected MobEnemy enemy;
    protected EnemyData enemyData;

    public MobEnemyState(MobEnemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName): base(stateMachine, animName)
    {
        this.enemy = enemy;
        this.enemyData = enemyData;
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
}
