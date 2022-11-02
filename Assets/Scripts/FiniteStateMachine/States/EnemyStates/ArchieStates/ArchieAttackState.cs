using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieAttackState : EnemyAttackState
{
    protected Vector2 attackDirection;
    protected float attackAngle;
    protected static float attackChargeUpTime = 0.5f;
    protected GameObject arrow;
    protected Transform spawnPosition;
    private GameObject arrowObj;

    public ArchieAttackState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName, GameObject arrow, Transform spawnPosition) : base(enemy, stateMachine, enemyData, animName)
    {
        this.arrow = arrow;
        this.spawnPosition = spawnPosition;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.velocity = Vector2.zero;
        attackDirection = (enemy.target.transform.position - enemy.transform.position).normalized;
        enemy.lookAt = attackDirection;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);

        attackAngle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, attackAngle - 90f));

        arrowObj = GameObject.Instantiate(this.arrow, this.spawnPosition.position, rot);
        Rigidbody2D arrow_rb = arrowObj.GetComponent<Rigidbody2D>();
        arrow_rb.velocity = attackDirection * enemyData.ProjectileSpeed;

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
        
        enemy.DestroyObject(arrowObj, 2f); //TODO: change the time to destroy object using enemy data

        AnimatorStateInfo animState = enemy.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("Attack") && animState.normalizedTime >= 1)
        {
            stateMachine.ChangeState(enemy.AgroState);
            return;
        }
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
