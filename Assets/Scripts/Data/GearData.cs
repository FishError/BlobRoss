using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGearData", menuName = "Data/Gear Data/Base Data")]
public class GearData : ScriptableObject
{
    [Header("Gear Rate")]
    public float rate = 1f;
}
