using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy Data/Archie Data")]
public class ArchieData : EnemyData
{
    // ratio method allows for attack properties to dynamically update if the base stats change
    [Header("Archer Properties")]
    public float ArcherDamageRatio;  // used to calculate archer damage by multiplying Attack by ArcherDamageScale
    public float ArcherSpeedRatio;   // used to calculate archer speed by multiplying MovementSpeed by ArcherSpeedScale
    public float ProjectileSpeed;
    public float DestroyTime;
}
