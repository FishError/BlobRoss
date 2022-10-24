using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipmentData", menuName = "Data/Equipment Data/Base Data")]
public class EquipmentData : ScriptableObject
{
    [Header("Equipment Rate")]
    public float rate = 1f;

    [Header("Shield")]
    public float duration = 1f;
    public float cooldown = 15f;
}
