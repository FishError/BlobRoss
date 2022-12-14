using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBaseAgroState : MobBaseState
{
    protected Vector2 targetDirection;

    public MobBaseAgroState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, Animator animator, string animName) : base(enemy, stateMachine, data, animator, animName) 
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        if (enemy.target == null)
        {
            stateMachine.ChangeState(enemy.IdleState);
            return;
        }

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
        if (enemy.target == null)
        {
            stateMachine.ChangeState(enemy.IdleState);
            return;
        }

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
