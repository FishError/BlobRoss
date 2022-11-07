using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : EnemyAttackState
{
    private List<BossAttack> Attacks;
    private BossAttack currentAttack;

    public BossAttackState(Dasher enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName)
    {
        Attacks = new List<BossAttack>();
    }

    public override void Enter()
    {
        base.Enter();
        // randomly choose attack from Attacks list
        currentAttack.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        currentAttack.Exit();
        currentAttack = null;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        currentAttack.LogicUpdate()
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        currentAttack.PhysicsUpdate()
    }
}
