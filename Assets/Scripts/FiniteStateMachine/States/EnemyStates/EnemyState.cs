using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;
    protected EnemyData enemyData;

    public EnemyState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData): base(stateMachine)
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
    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        
    }
}
