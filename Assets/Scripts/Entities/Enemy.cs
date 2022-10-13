using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    #region States
    public EnemyMoveTowardsTarget MoveTowardsTarget;
    public EnemyIdleState IdleState;
    public EnemyPatrolState PatrolState;
    #endregion

    #region Enemy Data
    [SerializeField] private EnemyData enemyData;
    #endregion

    #region Enemy Current Stats
    [Header("Health")]
    public float HealthPoints;
    public float Defense;

    [Header("Attack")]
    public float Attack;
    public float AttackSpeed;

    [Header("Move State")]
    public float PatrolVelocity;
    public float MovementVelocity;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        // initialize enemy states here
        MoveTowardsTarget = new EnemyMoveTowardsTarget(this, StateMachine);
        IdleState = new EnemyIdleState(this, StateMachine);
        PatrolState = new EnemyPatrolState(this, StateMachine);
    }

    protected override void Start()
    {
        base.Start();
        // initialize other variables and do additional setup
        StateMachine.Initialize(IdleState);

        HealthPoints = enemyData.HealthPoints;
        Defense = enemyData.Defense;
        Attack = enemyData.Attack;
        AttackSpeed = enemyData.AttackSpeed;
        PatrolVelocity = enemyData.PatrolVelocity;
        MovementVelocity = enemyData.MovementVelocity;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
