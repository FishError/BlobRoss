using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieAgroState : EnemyAgroState
{
    protected float moveDistance;
    protected Vector2 moveDirection;

    public ArchieAgroState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName)
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

        Vector2 attackDirection = (enemy.target.transform.position - enemy.transform.position).normalized;
        float distance = Vector2.Distance(enemy.target.transform.position, enemy.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, attackDirection, distance, enemy.unWalkableLayers);

        if (distance <= enemyData.AttackRange && enemy.AttackCoolDown <= 0 && hit.collider == null)
        {
            stateMachine.ChangeState(enemy.AttackState);
            return;
        }
        else if (distance > enemyData.AttackRange || hit.collider != null)
        {
            enemy.navMeshAgent.nextPosition = enemy.transform.position;
            enemy.navMeshAgent.SetDestination(enemy.target.transform.position);
            enemy.rb.velocity = enemy.navMeshAgent.velocity;
            enemy.lookAt = enemy.rb.velocity.normalized;
            enemy.SetAnimHorizontalVertical(enemy.lookAt);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        
    }
}
