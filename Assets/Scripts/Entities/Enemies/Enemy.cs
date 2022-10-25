using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    #region States 
    // base states that all children are required to have but dont always have use
    // children may also have more than just these states
    public EnemyIdleState IdleState { get; protected set; }
    public EnemyPatrolState PatrolState { get; protected set; }
    public EnemyAlertedState AlertedState { get; protected set; }
    public EnemyAgroState AgroState { get; protected set; }
    public EnemyAttackState AttackState { get; protected set; }
    public EnemyCCState CCState { get; protected set; }
    public EnemyDeathState DeathState { get; protected set; }
    #endregion

    #region Enemy Data
    [SerializeField] protected EnemyData enemyData;
    #endregion

    #region Enemy Current Stats
    // Health
    public float MaxHealthPoints { get; set; }
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

    #region Collision
    public Collision2D collision { get; protected set; }
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
    }

    protected override void Start()
    {
        base.Start();
        // initialize other variables and do additional setup
        StateMachine.Initialize(IdleState);

        MaxHealthPoints = enemyData.HealthPoints;
        HealthPoints = MaxHealthPoints;
        Defense = enemyData.Defense;
        Attack = enemyData.Attack;
        AttackSpeed = enemyData.AttackSpeed;
        PatrolVelocity = enemyData.PatrolVelocity;
        MovementVelocity = enemyData.MovementVelocity;
        lookAt = transform.right;

        // NavMeshAgent setup for navigation around obstacles
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = MovementVelocity;

        unWalkableLayers = LayerMask.GetMask("Wall");
        targetDetectionIgnoreLayers = LayerMask.GetMask("Grid", "Enemy");
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void SetAnimHorizontalVertical(Vector2 v)
    {
        Anim.SetFloat("Horizontal", v.x);
        Anim.SetFloat("Vertical", v.y);
    }

    public bool TargetDetected()
    {
        Vector2 dir = target.transform.position - transform.position;
        float angle = Vector2.Angle(dir, lookAt);

        if (angle < enemyData.FieldOfView / 2)
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
    public void ModifyMaxHealthPoints(float amt)
    {
        MaxHealthPoints += amt;
        if (MaxHealthPoints < 0) MaxHealthPoints = 0;
        ModifyHealthPoints(amt);
    }

    public void ScaleMaxHealthPoints(float percent)
    {
        MaxHealthPoints *= percent;
        if (MaxHealthPoints < 0) MaxHealthPoints = 0;
        ModifyHealthPoints(MaxHealthPoints * (percent - 1f));
    }

    public void ResetMaxHealthPoints()
    {
        MaxHealthPoints = enemyData.HealthPoints;
        if (HealthPoints > MaxHealthPoints) ResetHealthPoints();
    }

    public void ModifyHealthPoints(float amt)
    {
        HealthPoints += amt;
        if (HealthPoints < 0) HealthPoints = 0;
        else if (HealthPoints > MaxHealthPoints) HealthPoints = MaxHealthPoints;
    }

    public void ScaleHealthPoints(float percent)
    {
        HealthPoints *= percent;
        if (HealthPoints < 0) HealthPoints = 0;
        else if (HealthPoints > MaxHealthPoints) HealthPoints = MaxHealthPoints;
    }

    public void ResetHealthPoints()
    {
        HealthPoints = MaxHealthPoints;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.collision = collision;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.collision = null;
    }
}
