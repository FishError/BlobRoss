using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy Data/Blomb Data")]
public class BlombData : EnemyData
{
    [Header("Explosion")]
    public float ExplosionDamage;
    public float KnockbackForce;
    public float KnockbackDuration;
}
