using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
{
    [Header("Health")]
    public float HealthPoints = 100f;
    public float Defense = 5f;

    [Header("Attack")]
    public float Attack = 5f;
    public float AttackSpeed = 1f;

    [Header("Move State")]
    public float PatrolVelocity = 2f;
    public float MovementVelocity = 4f;
}
