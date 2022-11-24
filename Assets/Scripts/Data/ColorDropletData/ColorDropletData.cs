using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColorDropletData", menuName = "Data/Color Droplet Data")]
public class ColorDropletData : ScriptableObject
{
    [Header("Player Upgrades")]
    public float healPoints = 0f;

    [Header("Red Equipment Upgrades")]
    public float damageUpgrade = 0;
    public float attackSpeedUpgrade = 0f;

    [Header("Blue Equipment Upgrades")]
    public int durabilityUpgrade = 0;
    public float durationUpgrade = 0f;

    [Header("Yellow Equipment Upgrades")]
    public float cooldownUpgrade = 0f;
}
