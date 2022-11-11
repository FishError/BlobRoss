using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerProjectile : Projectile
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.ModifyHealthPoints(-damage);
            Destroy(gameObject);
        }

        base.OnCollisionEnter2D(collision);
    }
}
