using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : EnemyProjectile
{
    protected override void Start()
    {
        base.Start();
        SFXManager.Instance.PlayProjectileBasedAudio(this.audioSource, 0, 0.8f);
    }
}
