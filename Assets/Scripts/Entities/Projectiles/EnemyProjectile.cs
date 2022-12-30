using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.ModifyHealthPoints(-Damage);
            PlayerState playerState = (PlayerState) player.StateMachine.CurrentState;
            playerState.PlayPlayerBasedAudio(player, player.gameObject, 1, 0f, false);
        }

        base.OnCollisionEnter2D(collision);
    }

    public void PlayProjectileAudio(int index, float volume)
    {
        AudioSource audio = Object.Instantiate(audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = this.gameObject;
        audio.PlayOneShot(audioClips[index], volume);
    }
}
