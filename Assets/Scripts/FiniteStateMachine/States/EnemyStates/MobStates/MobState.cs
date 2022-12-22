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
    public MobState(FiniteStateMachine stateMachine, string animName) : base(stateMachine, animName)
    {
        
    }

    #region Idle Functions
    protected virtual float RandomIdleTime(EnemyData data)
    {
        return Random.Range(data.MinIdleDuration, data.MaxIdleDuration);
    }
    #endregion

    #region Patrol Functions
    protected virtual float RandomPatrolDistance(EnemyData data)
    {
        return Random.Range(data.MinPatrolDistance, data.MaxPatrolDistance);
    }

    protected virtual Vector2 RandomPatrolDirection(Mob enemy, float patrolDistance)
    {
        Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        RaycastHit2D hit = Physics2D.CircleCast(enemy.transform.position, 0.6f, randomVector, patrolDistance, enemy.unWalkableLayers);
        if (hit.collider == null)
        {
            return randomVector.normalized;
        }
        else
        {
            return ((Vector3)(hit.point + hit.normal * patrolDistance) - enemy.transform.position).normalized;
        }
    }
    #endregion

    #region Agro Functions
    protected virtual void NavigateToTarget(Mob enemy)
    {
        // set NavMeshDestination to target position to update path every FixedUpdate loop
        enemy.navMeshAgent.nextPosition = enemy.transform.position;
        enemy.navMeshAgent.SetDestination(new Vector3(enemy.target.transform.position.x, enemy.target.transform.position.y, 0));
        enemy.rb.velocity = enemy.navMeshAgent.velocity;
        enemy.lookAt = enemy.rb.velocity.normalized;
        enemy.SetAnimHorizontalVertical(enemy.lookAt);
    }
    #endregion

    #region Death Functions
    protected virtual void OnDeath(Mob enemy)
    {
        //Complete animation first and then destory gameobject
        AnimatorStateInfo animState = enemy.Anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName(animName) && animState.normalizedTime >= 1)
        {
            Object.Destroy(enemy.gameObject);

            if (enemy.lootDrop != null)
                Object.Instantiate(enemy.lootDrop, enemy.transform.position, Quaternion.identity);
        }
    }
    #endregion
}
