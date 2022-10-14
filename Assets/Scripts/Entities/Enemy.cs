using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    #region States
    public EnemyChaseTarget ChaseTargetState { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyPatrolState PatrolState { get; private set; }
    public EnemyAlertedState AlertedState { get; private set; }
    #endregion

    #region Enemy Data
    [SerializeField] private EnemyData enemyData;
    #endregion

    #region Enemy Current Stats
    // Health
    public float HealthPoints { get; set; }
    public float Defense { get; set; }

    // Attack
    public float Attack { get; set; }
    public float AttackSpeed { get; set; }

    // Move State
    public float PatrolVelocity { get; set; }
    public float MovementVelocity { get; set; }
    #endregion

    [Header("Target Detection")]
    public GameObject target;
    public float FOV;
    public float detectionRange;
    public Vector2 lookAt { get; set; }
    public LayerMask layersToIgnore { get; set; }

    protected override void Awake()
    {
        base.Awake();
        // initialize enemy states here
        ChaseTargetState = new EnemyChaseTarget(this, StateMachine);
        IdleState = new EnemyIdleState(this, StateMachine);
        PatrolState = new EnemyPatrolState(this, StateMachine);
        AlertedState = new EnemyAlertedState(this, StateMachine);
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
        lookAt = transform.right;
        layersToIgnore = LayerMask.GetMask("Grid", "Enemy");
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public bool TargetDetected()
    {
        Vector2 dir = target.transform.position - transform.position;
        float angle = Vector2.Angle(dir, lookAt);

        if (angle < FOV / 2)
        {
            RaycastHit2D r = Physics2D.Raycast(transform.position, dir, detectionRange, ~layersToIgnore);
            if (r.collider.gameObject == target)
            {
                return true;
            }
        }

        return false;
    }

    public RaycastHit2D CheckForObstacles(Vector2 dir)
    {
        return Physics2D.Raycast(transform.position, dir, detectionRange, ~layersToIgnore);
    }
}
