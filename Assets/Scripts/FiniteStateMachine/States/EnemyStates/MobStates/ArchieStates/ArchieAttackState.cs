using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieAttackState : ArchieState
{
    protected float attackAngle;
    protected GameObject arrow;
    protected Transform spawnPosition;

    public ArchieAttackState(Archie archie, FiniteStateMachine stateMachine, ArchieData data, Animator animator, string animName, GameObject arrow, Transform spawnPosition) : base(archie, stateMachine, data, animator, animName)
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

        AnimatorStateInfo animState = archie.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName(animName) && animState.normalizedTime >= 1)
        {
            archie.lookAt = targetDirection;
            archie.SetAnimHorizontalVertical(archie.lookAt);

            attackAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, attackAngle));

            GameObject arrowObj = Object.Instantiate(this.arrow, spawnPosition.position, rot);
            Arrow arrow = arrowObj.GetComponent<Arrow>();
            arrow.SetDamage(archie.Attack);
            arrow.SetVelocity(targetDirection);
        }

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
