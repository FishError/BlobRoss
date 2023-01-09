using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MobStates
{
    Spawn,
    Idle,
    Patrol,
    Alerted,
    Agro,
    Attack,
    CC,
    Death
}

public class Mob : Enemy
{
    #region States 
    // base states that all children are required to have but dont always have use
    // children may also have more than just these states
    public MobState SpawnState { get; protected set; }
    public MobState IdleState { get; protected set; }
    public MobState PatrolState { get; protected set; }
    public MobState AlertedState { get; protected set; }
    public MobState AgroState { get; protected set; }
    public MobState AttackState { get; protected set; }
    public MobState CCState { get; protected set; }
    public MobState DeathState { get; protected set; }

    [Header("State Settings")]
    public MobStates initialState;
    #endregion

    #region Enemy Current Stats
    // Attack
    public float AttackCoolDown { get; set; }

    // Move State
    public float PatrolSpeed { get; set; }
    #endregion

    #region Others
    public bool isDeathStateCalled = false;
    #endregion

    protected override void Start()
    {
        base.Start();
        PatrolSpeed = ((EnemyData)data).PatrolSpeed;

        switch (initialState)
        {
            case MobStates.Spawn:
                StateMachine.Initialize(SpawnState);
                break;
            case MobStates.Idle:
                StateMachine.Initialize(IdleState);
                break;
            case MobStates.Patrol:
                StateMachine.Initialize(PatrolState);
                break;
            case MobStates.Alerted:
                StateMachine.Initialize(AlertedState);
                break;
            case MobStates.Agro:
                StateMachine.Initialize(AgroState);
                break;
            case MobStates.Attack:
                StateMachine.Initialize(AttackState);
                break;
            case MobStates.CC:
                StateMachine.Initialize(CCState);
                break;
            case MobStates.Death:
                StateMachine.Initialize(DeathState);
                break;
        }
    }

    protected override void Update()
    {
        base.Update();

        //TODO might have to move this up a level because Blob/player needs to be in same death
        if (HealthPoints <= 0 && !isDeathStateCalled)
        {
            StateMachine.ChangeState(DeathState);
        }

        if (AttackCoolDown > 0)
            AttackCoolDown -= Time.deltaTime;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            if (StateMachine.CurrentState != AttackState && StateMachine.CurrentState != CCState)
            {
                collision.gameObject.GetComponent<Player>().ModifyHealthPoints(-Attack);
            }
            if (!alerted)
            {
                StateMachine.ChangeState(AlertedState);
            }
        }
    }
}
