using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.ModifyHealthPoints(-Damage);
            SFXManager.Instance.PlayPlayerRelatedAudio(player, player.gameObject, 1, 0f, false);
        }

        base.OnCollisionEnter2D(collision);
    }
}
