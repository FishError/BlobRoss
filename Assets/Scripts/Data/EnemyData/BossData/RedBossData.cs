using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRedBossData", menuName = "Data/Enemy Data/Boss Data")]
public class RedBossData : BossData
{
    [Space(15)]
    [Header("Phase 1 Attacks")]
    [Header("Mortar Strike")]
    public int MaxMortarStrike;
    public float MortarStrikeDamageRatio;
    public float MortarStrikeRange;
    public float MortarStrikeCooldown;

    [Header("Firebolt")]
    public int MaxFireboltAmount;
    public float FireboltDamageRatio;
    public float FireboltRange;
    public float FireboltCooldown;

    [Space(15)]
    [Header("Phase 2 Attacks")]
    [Header("Blomb Squad")]
    public int MaxBlombSummons;
    public float IntervalBetweenSummons;
    public float BlombSquadDamageRatio;
    public float BlombSquadRange;
    public float BlombSquadCooldown;

    [Header("Wheel Of Fire")]
    public int MaxWaveAmount;
    public float RotationBetweenWaves;
    public float WheelOfFireDamageRatio;
    public float WheelOfFireHellRange;
    public float WheelOfFireCooldown;
}
