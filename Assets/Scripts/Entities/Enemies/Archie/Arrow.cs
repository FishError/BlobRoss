using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Archie archie;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            Destroy(gameObject);
            player.ModifyHealthPoints(-archie.Attack * archie.ArcherDamageRatio);
        }
    }
}
