using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;

    public EnemyState(Enemy enemy, FiniteStateMachine stateMachine): base(stateMachine)
    {
        this.enemy = enemy;
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
