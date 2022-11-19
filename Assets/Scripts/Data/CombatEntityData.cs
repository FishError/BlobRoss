using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityData : ScriptableObject
{
    [Header("Defensive Stats")]
    public float HealthPoints;
    public float Defense;

    [Header("Attack Stats")]
    public float Attack;
    public float AttackSpeed;

    [Header("Movement Stats")]
    public float MovementSpeed;
}
