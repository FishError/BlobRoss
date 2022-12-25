using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrowdControl
{
    Knockback,
    Stunned,
    Frozen,
    Snarred
}

public class MobState : EnemyState
{
    public MobState(FiniteStateMachine stateMachine, Animator animator, string animName) : base(stateMachine, animator, animName)
    {
        
    }

    protected virtual void NavigateToTarget(Mob enemy)
    {
        // set NavMeshDestination to target position to update path every FixedUpdate loop
        enemy.navMeshAgent.nextPosition = enemy.transform.position;
        enemy.navMeshAgent.SetDestination(new Vector3(enemy.target.transform.position.x, enemy.target.transform.position.y, 0));
        enemy.rb.velocity = enemy.navMeshAgent.velocity;
        enemy.lookAt = enemy.rb.velocity.normalized;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }
}
