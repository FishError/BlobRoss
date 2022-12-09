using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : CombatOrganismEntity
{
    #region NavMesh
    public NavMeshAgent navMeshAgent { get; private set; }
    #endregion

    [Header("Drops On Death")]
    public GameObject lootDrop;

    [Header("Target Detection")]
    public GameObject target;
    public bool alerted { get; set; }
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

        MaxHealthPoints = data.HealthPoints;
        HealthPoints = MaxHealthPoints;
        Defense = data.Defense;
        Attack = data.Attack;
        AttackSpeed = data.AttackSpeed;
        MovementSpeed = data.MovementSpeed;

        lookAt = transform.right;

        // NavMeshAgent setup for navigation around obstacles
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = MovementSpeed;

        unWalkableLayers = LayerMask.GetMask("Wall");
        targetDetectionIgnoreLayers = LayerMask.GetMask("Ignore Raycast", "Enemy");
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
        if (target != null)
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
        }

        return false;
    }

    public void DestroyObject(GameObject obj, float time)
    {
        Destroy(obj, time);
    }
}
