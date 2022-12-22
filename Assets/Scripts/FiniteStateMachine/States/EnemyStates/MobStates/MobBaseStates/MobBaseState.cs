using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBaseState : MobState
{
    protected Mob enemy;
    protected EnemyData data;

    public MobBaseState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, string animName) : base(stateMachine, animName)
    {
        this.enemy = enemy;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        startPosition = enemy.transform.position;
        enemy.Anim.SetBool(animName, true);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.Anim.SetBool(animName, false);
    }

    public override void LogicUpdate()
    {
        distance = Vector2.Distance(enemy.target.transform.position, enemy.transform.position);
    }
}
