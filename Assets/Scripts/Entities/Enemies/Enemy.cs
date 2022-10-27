using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : CombatEntity
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

    #region Enemy Current Stats
    // Attack
    public float AttackCoolDown { get; set; }

    // Move State
    public float PatrolSpeed { get; set; }
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
    }

    protected override void Start()
    {
        base.Start();
        // initialize other variables and do additional setup
        StateMachine.Initialize(IdleState);

        MaxHealthPoints = data.HealthPoints;
        HealthPoints = MaxHealthPoints;
        Defense = data.Defense;
        Attack = data.Attack;
        AttackSpeed = data.AttackSpeed;
        PatrolSpeed = ((EnemyData)data).PatrolSpeed;
        MovementSpeed = data.MovementSpeed;

        lookAt = transform.right;

        // NavMeshAgent setup for navigation around obstacles
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = MovementSpeed;

        unWalkableLayers = LayerMask.GetMask("Wall");
        targetDetectionIgnoreLayers = LayerMask.GetMask("Grid", "Enemy");
    }

    protected override void Update()
    {
        base.Update();
        if (AttackCoolDown > 0)
            AttackCoolDown -= Time.deltaTime;
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

        if (angle < ((EnemyData)data).FieldOfView / 2)
        {
            RaycastHit2D r = Physics2D.Raycast(transform.position, dir, ((EnemyData)data).DetectionRange, ~targetDetectionIgnoreLayers);
            if (r.collider != null && r.collider.gameObject == target)
            {
                return true;
            }
        }

        return false;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().ModifyHealthPoints(-Attack);
        }
    }
}
