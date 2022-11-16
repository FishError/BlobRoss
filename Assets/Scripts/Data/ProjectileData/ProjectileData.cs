using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectileData", menuName = "Data/Projectile")]
public class ProjectileData : ScriptableObject
{
    public float DamageRatio;
    public float Speed;
    public float LifeTime = Mathf.Infinity;
    public float LifeDistance = Mathf.Infinity;
}
