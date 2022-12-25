using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBaseState : MobState
{
    protected Mob enemy;
    protected EnemyData data;

    public MobBaseState(Mob enemy, FiniteStateMachine stateMachine, EnemyData data, Animator animator, string animName) : base(stateMachine, animator, animName)
    {
        this.enemy = enemy;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        startPosition = enemy.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        distance = Vector2.Distance(enemy.target.transform.position, enemy.transform.position);
    }
}
