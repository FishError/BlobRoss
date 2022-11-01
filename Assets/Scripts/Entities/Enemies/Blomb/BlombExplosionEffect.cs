using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlombExplosionEffect : MonoBehaviour
{
    public Blomb blomb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.CCState.SetKnockbackValues(-collision.GetContact(0).normal * blomb.KnockbackForce, blomb.KnockbackDuration);
            player.StateMachine.ChangeState(player.CCState);
            player.ModifyHealthPoints(-blomb.ExplosionDamage);
        }
    }
}
