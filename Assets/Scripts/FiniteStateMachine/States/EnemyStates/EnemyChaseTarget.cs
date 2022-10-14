using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseTarget : EnemyState
{
    protected LayerMask obstacles;

    public EnemyChaseTarget(Enemy enemy, FiniteStateMachine stateMachine) : base(enemy, stateMachine) 
    {
        obstacles = LayerMask.GetMask("Wall");
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Vector2 dir = (enemy.target.transform.position - enemy.transform.position).normalized;
        Vector2 dir2 = Vector2.zero;
        Debug.Log("before: " + dir);
        RaycastHit2D r1 = Physics2D.Raycast(enemy.transform.position, dir, 3, obstacles);
        if (r1.collider)
            dir2 += r1.normal;

        RaycastHit2D r2 = Physics2D.Raycast(enemy.transform.position, Rotate(dir, 45), 3, obstacles);
        if (r2.collider)
            dir2 += r2.normal;

        RaycastHit2D r3 = Physics2D.Raycast(enemy.transform.position, Rotate(dir, -45), 3, obstacles);
        if (r3.collider)
            dir2 += r3.normal;

        Debug.Log("after: " + dir);
        enemy.SetVelocity(3, dir * 0.7f + dir2 * 0.3f);
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected Vector2 Rotate(Vector2 v, float angle)
    {
        float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
        float cos = Mathf.Cos(angle * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        float x = (cos * tx) - (sin * ty);
        float y = (sin * tx) + (cos * ty);

        return new Vector2(x, y);
    }
}
