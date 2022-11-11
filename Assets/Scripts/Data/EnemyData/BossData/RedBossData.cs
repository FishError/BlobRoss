using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRedBossData", menuName = "Data/Enemy Data/Boss Data")]
public class RedBossData : CombatEntityData
{
    [Header("Phase 1 Attacks")]
    [Header("Mortar Strike")]
    public int MaxMortarStrike;
    public float MortarStrikeDamageRatio;
    public float MortarStrikeRange;
    public float MortarStrikeCooldown;

    [Header("Fire Ball")]
    public int MaxFireballAmount;
    public float FireBallDamageRatio;
    public float FireBallRange;
    public float FireBallCooldown;

    [Header("Phase 2 Attacks")]
    [Header("Summon Blombs")]
    public float SummonBlombsDamageRatio;
    public float SummonBlombsRange;
    public float SummonBlombsCooldown;

    [Header("Fire Ball Bullet Hell")]
    public float FireBallBulletHellDamageRatio;
    public float FireBallBulletHellRange;
    public float FireBallBulletHellCooldown;
}
