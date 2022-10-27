using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : CombatEntityData
{
    [Header("Detection")]
    public float FieldOfView = 130f;
    public float DetectionRange = 8f;

    [Header("Idle State")]
    public float MinIdleDuration = 1f;
    public float MaxIdleDuration = 2f;

    [Header("Patrol State")]
    public float PatrolSpeed = 2f;
    public float MinPatrolDistance = 2f;
    public float MaxPatrolDistance = 4f;

    [Header("Alert State")]
    public float AlertTime = 1f;

    [Header("Attack State")]
    public float AttackRange;
}
