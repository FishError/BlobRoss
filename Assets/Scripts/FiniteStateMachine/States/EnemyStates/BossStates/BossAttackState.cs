using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossEnemyState
{
    private BossAttack currentAttack;

    public BossAttackState(RedBoss boss, FiniteStateMachine stateMachine, RedBossData data, string animName) : base(boss, stateMachine, data, animName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
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
        currentAttack.LogicUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        currentAttack.PhysicsUpdate();
    }

    public void SetCurrentAttack(BossAttack attack)
    {
        currentAttack = attack;
    }
}
