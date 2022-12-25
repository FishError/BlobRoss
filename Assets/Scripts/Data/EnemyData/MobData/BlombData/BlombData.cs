using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlombData", menuName = "Data/Enemy Data/Mob Data/Blomb Data")]
public class BlombData : MobData
{
    [Header("Explosion Properties")]
    public float ExplosionDamageRatio;
    public float KnockbackForce;
    public float KnockbackDuration;
}
