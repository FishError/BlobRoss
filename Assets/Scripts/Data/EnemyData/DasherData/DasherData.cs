using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDasherData", menuName = "Data/Enemy Data/Dasher Data")]
public class DasherData : EnemyData
{
    // ratio method allows for attack properties to dynamically update if the base stats change
    [Header("Dash Properties")]
    public float DashDamageRatio;  // used to calculate dash damage by multiplying Attack by DashDamageScale
    public float DashSpeedRatio;   // used to calculate dash speed by multiplying MovementSpeed by DashSpeedScale
    public float KnockbackForce;
    public float KnockbackDuration;
}
