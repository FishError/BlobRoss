using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : CombatEntityData
{
    [Header("Crit")]
    public float CritRate = 0.05f;
    public float CritDamage = 0.5f;
}
