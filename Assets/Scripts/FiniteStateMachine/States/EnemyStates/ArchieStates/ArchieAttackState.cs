using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieAttackState : EnemyAttackState
{
    protected float attackAngle;
    protected GameObject arrow;
    protected Transform spawnPosition;
    private GameObject arrowObj;

    public ArchieAttackState(Archie enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName, GameObject arrow, Transform spawnPosition) : base(enemy, stateMachine, enemyData, animName)
    {
        this.arrow = arrow;
        this.spawnPosition = spawnPosition;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        enemy.lookAt = targetDirection;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);

        attackAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, attackAngle - 90f));

        arrowObj = GameObject.Instantiate(this.arrow, this.spawnPosition.position, rot);
        arrowObj.GetComponent<Arrow>().archie = (Archie)enemy;
        Rigidbody2D arrow_rb = arrowObj.GetComponent<Rigidbody2D>();
        arrow_rb.velocity = targetDirection * ((Archie)enemy).ProjectileSpeed;

        enemy.DestroyObject(arrowObj, ((Archie)enemy).DestroyTime);

    }

    public override void Exit()
    {
        base.Exit();
        enemy.rb.velocity = Vector2.zero;
        enemy.AttackCoolDown = 1 / enemyData.AttackSpeed;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        ChangeStateAfterAnimation(animName, enemy.AgroState);
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
