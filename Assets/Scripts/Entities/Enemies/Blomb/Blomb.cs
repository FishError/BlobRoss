using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blomb : Enemy
{
    public GameObject fieldOnDeath;

    protected override void Awake()
    {
        base.Awake();
        IdleState = new BlombIdleState(this, StateMachine, (EnemyData)data, "Idle");
        PatrolState = new BlombPatrolState(this, StateMachine, (EnemyData)data, "Move");
        AlertedState = new BlombAlertedState(this, StateMachine, (EnemyData)data, "Idle");
        AgroState = new BlombAgroState(this, StateMachine, (EnemyData)data, "Move");
        AttackState = new BlombAttackState(this, StateMachine, (EnemyData)data, "Attack");
        CCState = new EnemyCCState(this, StateMachine, (EnemyData)data, "Idle");
        DeathState = new BlombDeathState(this, StateMachine, (EnemyData)data, "Death");
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        StateMachine.CurrentState.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "Player" && StateMachine.CurrentState != AttackState)
        {
            StateMachine.ChangeState(AlertedState);
            collision.gameObject.GetComponent<Player>().ModifyHealthPoints(-Attack/2);
        }
    }
}
