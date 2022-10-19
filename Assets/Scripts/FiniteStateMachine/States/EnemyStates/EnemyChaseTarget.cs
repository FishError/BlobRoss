using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseTarget : EnemyState
{
    public EnemyChaseTarget(Enemy enemy, FiniteStateMachine stateMachine) : base(enemy, stateMachine) 
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

        // set NavMeshDestination to target position to update path every FixedUpdate loop
        enemy.navMeshAgent.nextPosition = enemy.transform.position;
        enemy.navMeshAgent.SetDestination(enemy.target.transform.position);
        enemy.rb.velocity = enemy.navMeshAgent.velocity;
        enemy.lookAt = enemy.rb.velocity.normalized;
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
