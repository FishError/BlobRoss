using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipmentData", menuName = "Data/Equipment Data/Base Data")]
public class EquipmentData : ScriptableObject
{
    [Header("Equipment Rate")]
    public float rate = 1f;

    [Header("Yellow Equipment Stats")]
    public float DashVelocity = 0f;
    public float DashCooldown = 0f;
    public float Duration = 0f;
}
