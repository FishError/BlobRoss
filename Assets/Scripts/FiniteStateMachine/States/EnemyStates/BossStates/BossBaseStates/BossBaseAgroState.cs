using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseAgroState : BossBaseState
{
    private float waitAttackTimer;

    public BossBaseAgroState(Boss boss, FiniteStateMachine stateMachine, BossData data, Animator animator, string animName) : base(boss, stateMachine, data, animator, animName) 
    {

    }

    public override void Enter()
    {
        base.Enter();
        boss.SetAnimHorizontalVertical(boss.lookAt);
        waitAttackTimer = Time.time + boss.waitTimeBetweenAttacks;
    }

    public override void Exit()
    {
        base.Exit();
        boss.SetAnimHorizontalVertical(boss.lookAt);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= waitAttackTimer)
        {
            List<BossAttack> attacks = boss.AvaliableAttacks();
            if (attacks.Count > 0)
            {
                boss.AttackState.SetCurrentAttack(attacks[Random.Range(0, attacks.Count - 1)]);
                stateMachine.ChangeState(boss.AttackState);
            }
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        boss.navMeshAgent.nextPosition = boss.transform.position;
        boss.navMeshAgent.SetDestination(boss.target.transform.position);
        boss.rb.velocity = boss.navMeshAgent.velocity;
        boss.lookAt = boss.rb.velocity.normalized;
        boss.SetAnimHorizontalVertical(boss.lookAt);
    }
}
