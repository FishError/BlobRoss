using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public ProjectileData data;
    public AudioSource audioSource;

    public float DamageRatio { get; set; }
    public float Damage { get; set; }
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }
    public float LifeTime { get; private set; }
    public float LifeDistance { get; private set; }


    public Rigidbody2D rb;

    protected Vector2 startPosition;
    protected Vector2 previousPosition;
    protected float distanceTraveled;
    protected float timeAlive;

    protected virtual void Awake()
    {
        DamageRatio = data.DamageRatio;
        Speed = data.Speed;
        LifeTime = data.LifeTime;
        LifeDistance = data.LifeDistance;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        previousPosition = startPosition;

        if (rb != null)
            rb.velocity = Direction * Speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        distanceTraveled += Vector2.Distance(previousPosition, transform.position);
        timeAlive += Time.deltaTime;
        if (distanceTraveled >= LifeDistance || timeAlive >= LifeTime)
            Destroy(gameObject);

        previousPosition = transform.position;
    }

    protected virtual void FixedUpdate()
    {
        if (rb != null)
            rb.velocity = Direction * Speed;
    }

    public virtual void SetDamage(float attack)
    {
        Damage = attack * DamageRatio;
    }

    public virtual void SetVelocity(Vector2 dir)
    {
        Direction = dir;
    }

    public virtual void SetVelocity(Vector2 dir, float speed)
    {
        Direction = dir;
        Speed = speed;
    }

    public virtual void SetLifeTime(float t)
    {
        timeAlive = 0;
        LifeTime = t;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
