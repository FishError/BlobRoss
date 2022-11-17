using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgroState : EnemyState
{
    protected float distance;
    protected Vector2 targetDirection;

    public EnemyAgroState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) 
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        distance = Vector2.Distance(enemy.target.transform.position, enemy.transform.position);
        targetDirection = (enemy.target.transform.position - enemy.transform.position).normalized;
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
        enemy.navMeshAgent.SetDestination(new Vector3(enemy.target.transform.position.x, enemy.target.transform.position.y, 0));
        enemy.rb.velocity = enemy.navMeshAgent.velocity;
        enemy.lookAt = enemy.rb.velocity.normalized;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }
}
