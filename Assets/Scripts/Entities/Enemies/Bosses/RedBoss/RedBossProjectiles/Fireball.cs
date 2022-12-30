using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : EnemyProjectile
{
    public void PlayOnSpecificVolume(float volume)
    {
        PlayProjectileAudio(0, volume);
    }
}
