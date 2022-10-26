using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
{
    [Header("Health")]
    public float HealthPoints;
    public float Defense;

    [Header("Attack")]
    public float Attack;
    [Tooltip("Number of attacks per second")]
    public float AttackSpeed;
    public float AttackRange;

    [Header("Move State")]
    public float PatrolSpeed;
    public float MovementSpeed;

    [Header("Detection")]
    public float FieldOfView = 130f;
    public float DetectionRange = 8f;

    [Header("Idle State")]
    public float MinIdleDuration = 1f;
    public float MaxIdleDuration = 2f;

    [Header("Patrol State")]
    public float MinPatrolDistance = 2f;
    public float MaxPatrolDistance = 4f;

    [Header("Patrol State")]
    public float AlertTime = 1f;
}
