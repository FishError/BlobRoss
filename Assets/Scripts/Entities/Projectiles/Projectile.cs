using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage;
    public Vector2 dir;
    public float speed;

    public Rigidbody2D rb;

    public float lifeTime = Mathf.Infinity;
    public float lifeDistance = Mathf.Infinity;

    protected Vector2 startPosition;
    protected float distanceTraveled;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = dir * speed;

        startPosition = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (rb != null)
            rb.velocity = dir * speed;

        distanceTraveled = Vector2.Distance(startPosition, transform.position);
        if (distanceTraveled >= lifeDistance)
            Destroy(gameObject);
    }

    public virtual void SetVelocity(Vector2 dir, float speed)
    {
        this.dir = dir;
        this.speed = speed;
    }

    public virtual void SetLifeTime(float t)
    {
        lifeTime = t;
        Destroy(gameObject, lifeTime);
    }
}
