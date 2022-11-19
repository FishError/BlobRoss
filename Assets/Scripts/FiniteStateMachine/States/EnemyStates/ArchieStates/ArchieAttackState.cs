using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieAttackState : EnemyAttackState
{
    private Archie archie;
    private ArchieData data;

    protected float attackAngle;
    protected GameObject arrow;
    protected Transform spawnPosition;
    private GameObject arrowObj;

    public ArchieAttackState(Archie archie, FiniteStateMachine stateMachine, ArchieData data, string animName, GameObject arrow, Transform spawnPosition) : base(archie, stateMachine, data, animName)
    {
        this.archie = archie;
        this.data = data;

        this.arrow = arrow;
        this.spawnPosition = spawnPosition;
    }

    public override void Enter()
    {
        base.Enter();
        archie.rb.velocity = Vector2.zero;
        archie.lookAt = targetDirection;
        archie.SetAnimHorizontalVertical(archie.lookAt);

        attackAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, attackAngle - 90f));

        arrowObj = GameObject.Instantiate(this.arrow, this.spawnPosition.position, rot);
        arrowObj.GetComponent<Arrow>().archie = archie;
        Rigidbody2D arrow_rb = arrowObj.GetComponent<Rigidbody2D>();
        arrow_rb.velocity = targetDirection * archie.ProjectileSpeed;

        archie.DestroyObject(arrowObj, archie.DestroyTime);

    }

    public override void Exit()
    {
        base.Exit();
        archie.rb.velocity = Vector2.zero;
        archie.AttackCoolDown = 1 / data.AttackSpeed;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        ChangeStateAfterAnimation(archie, animName, archie.AgroState);
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
