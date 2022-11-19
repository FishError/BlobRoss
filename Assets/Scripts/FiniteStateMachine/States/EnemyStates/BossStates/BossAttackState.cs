using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossEnemyState
{
    private BossAttack currentAttack;

    public BossAttackState(RedBoss boss, FiniteStateMachine stateMachine, RedBossData data, string animName = null) : base(boss, stateMachine, data, animName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        boss.rb.velocity = Vector2.zero;
        if (currentAttack != null)
            currentAttack.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        if (currentAttack != null)
            currentAttack.Exit();
        currentAttack = null;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (currentAttack != null)
            currentAttack.LogicUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (currentAttack != null)
            currentAttack.PhysicsUpdate();
    }

    public void SetCurrentAttack(BossAttack attack)
    {
        currentAttack = attack;
    }
}
