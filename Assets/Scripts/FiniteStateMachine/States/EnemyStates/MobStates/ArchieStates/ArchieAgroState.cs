using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieAgroState : ArchieState
{
    protected float moveDistance;
    protected Vector2 moveDirection;
    protected RaycastHit2D hit;

    public ArchieAgroState(Archie archie, FiniteStateMachine stateMachine, ArchieData data, string animName) : base(archie, stateMachine, data, animName)
    {
        this.archie = archie;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();

        if (archie.target == null)
        {
            stateMachine.ChangeState(archie.IdleState);
            return;
        }
        
        archie.SetAnimHorizontalVertical(archie.lookAt);
    }

    public override void Exit()
    {
        base.Exit();
        archie.SetAnimHorizontalVertical(archie.lookAt);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        hit = Physics2D.Raycast(archie.transform.position, targetDirection, distance, archie.unWalkableLayers);

        if (distance <= data.AttackRange && archie.AttackCoolDown <= 0 && hit.collider == null)
        {
            stateMachine.ChangeState(archie.AttackState);
            return;
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        if (distance > data.AttackRange || hit.collider != null)
        {
            archie.navMeshAgent.nextPosition = archie.transform.position;
            archie.navMeshAgent.SetDestination(archie.target.transform.position);
            archie.rb.velocity = archie.navMeshAgent.velocity;
            archie.lookAt = archie.rb.velocity.normalized;
            archie.SetAnimHorizontalVertical(archie.lookAt);
        }
    }
}
