using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgroState : EnemyState
{
    public EnemyAgroState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData) : base(enemy, stateMachine, enemyData) 
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // set NavMeshDestination to target position to update path every FixedUpdate loop
        enemy.navMeshAgent.nextPosition = enemy.transform.position;
        enemy.navMeshAgent.SetDestination(enemy.target.transform.position);
        enemy.rb.velocity = enemy.navMeshAgent.velocity;
        enemy.lookAt = enemy.rb.velocity.normalized;
    }
}
