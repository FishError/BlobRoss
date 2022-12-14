using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipmentData", menuName = "Data/Equipment Data/Base Data")]
public class EquipmentData : ScriptableObject
{
    [Header("Equipment Rate")]
    public float rate = 1f;

    [Header("Red Equipment Stats")]
    public float Damage = 0f;
    public float attackSpeed = 0f;

    [Header("Yellow Equipment Stats")]
    public float DashVelocity = 0f;
    public float DashCooldown = 0f;
    public float Duration = 0f;

    [Header("Blue Equipment Stats")]
    public float duration = 0f;
    public int durability = 0;
    public float knockback = 0f;
    public float cooldown = 0f;
    public float range = 0f;
}
