using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    #region NavMesh
    public NavMeshAgent navMeshAgent { get; private set; }
    #endregion

    [Header("Target Detection")]
    public GameObject target;
    public Vector2 lookAt { get; set; }

    public LayerMask unWalkableLayers { get; set; }
    public LayerMask targetDetectionIgnoreLayers { get; set; }


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

        unWalkableLayers = LayerMask.GetMask("Wall");
        targetDetectionIgnoreLayers = LayerMask.GetMask("Grid", "Enemy");

        // NavMeshAgent setup for navigation around obstacles
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = MovementVelocity;
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

        if (angle < enemyData.FieldOFView / 2)
        {
            RaycastHit2D r = Physics2D.Raycast(transform.position, dir, enemyData.DetectionRange, ~targetDetectionIgnoreLayers);
            if (r.collider != null && r.collider.gameObject == target)
            {
                return true;
            }
        }

        return false;
    }

    #region Stat Modifier Functions
    // Health
    public void ModifyHealthPoints(float amt)
    {
        HealthPoints += amt;
        if (HealthPoints < 0) HealthPoints = 0;
    }

    public void ScaleHealthPoints(float percent)
    {
        HealthPoints *= percent;
        if (HealthPoints < 0) HealthPoints = 0;
    }

    public void ResetHealthPoints()
    {
        HealthPoints = enemyData.HealthPoints;
    }

    // Defense
    public void ModifyDefense(float amt)
    {
        Defense += amt;
        if (Defense < 0) Defense = 0;
    }

    public void ScaleDefense(float percent)
    {
        Defense *= percent;
        if (Defense < 0) Defense = 0;
    }

    public void ResetDefense()
    {
        Defense = enemyData.Defense;
    }

    // Attack
    public void ModifyAttack(float amt)
    {
        Attack += amt;
        if (Attack < 0) Attack = 0;
    }

    public void ScaleAttack(float percent)
    {
        Attack *= percent;
        if (Attack < 0) Attack = 0;
    }

    public void ResetAttack()
    {
        Attack = enemyData.Attack;
    }

    // Attack Speed
    public void ModifyAttackSpeed(float amt)
    {
        AttackSpeed += amt;
        if (AttackSpeed < 0) AttackSpeed = 0;
    }

    public void ScaleAttackSpeed(float percent)
    {
        AttackSpeed *= percent;
        if (AttackSpeed < 0) AttackSpeed = 0;
    }

    public void ResetAttackSpeed()
    {
        AttackSpeed = enemyData.AttackSpeed;
    }

    // Velocity
    public void ModifyVelocity(float amt)
    {
        PatrolVelocity += amt;
        if (PatrolVelocity < 0) PatrolVelocity = 0;
        MovementVelocity += amt;
        if (MovementVelocity < 0) MovementVelocity = 0;
    }

    public void ScaleVelocity(float percent)
    {
        PatrolVelocity *= percent;
        if (PatrolVelocity < 0) PatrolVelocity = 0;
        MovementVelocity *= percent;
        if (MovementVelocity < 0) MovementVelocity = 0;

    }

    public void ResetVelocity()
    {
        PatrolVelocity = enemyData.PatrolVelocity;
        MovementVelocity = enemyData.MovementVelocity;
    }
    #endregion
}
