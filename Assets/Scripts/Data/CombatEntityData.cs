using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityData : ScriptableObject
{
    [Header("Health")]
    public float HealthPoints;
    public float Defense;

    [Header("Attack")]
    public float Attack;
    public float AttackSpeed;

    [Header("Move State")]
    public float MovementSpeed;
}
