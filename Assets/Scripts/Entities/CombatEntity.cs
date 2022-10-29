using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntity : Entity
{
    #region Combat Entity Data
    [SerializeField] protected CombatEntityData data;
    #endregion

    #region Comabt Entity Current Stats
    // Health & Defense
    public float MaxHealthPoints { get; set; }
    public float HealthPoints { get; set; }
    public float Defense { get; set; }

    // Attack
    public float Attack { get; set; }
    public float AttackSpeed { get; set; }

    // Move State
    public float MovementSpeed { get; set; }
    #endregion

    #region Stat Modifer Functions
    // Health
    public void ModifyMaxHealthPoints(float amt)
    {
        MaxHealthPoints += amt;
        if (MaxHealthPoints < 0) MaxHealthPoints = 0;
        ModifyHealthPoints(amt);
    }

    public void ScaleMaxHealthPoints(float percent)
    {
        MaxHealthPoints *= percent;
        if (MaxHealthPoints < 0) MaxHealthPoints = 0;
        ModifyHealthPoints(MaxHealthPoints * (percent - 1f));
    }

    public void ResetMaxHealthPoints()
    {
        MaxHealthPoints = data.HealthPoints;
        if (HealthPoints > MaxHealthPoints) ResetHealthPoints();
    }

    public void ModifyHealthPoints(float amt)
    {
        HealthPoints += amt;
        if (HealthPoints < 0) HealthPoints = 0;
        else if (HealthPoints > MaxHealthPoints) HealthPoints = MaxHealthPoints;
    }

    public void ScaleHealthPoints(float percent)
    {
        HealthPoints *= percent;
        if (HealthPoints < 0) HealthPoints = 0;
        else if (HealthPoints > MaxHealthPoints) HealthPoints = MaxHealthPoints;
    }

    public void ResetHealthPoints()
    {
        HealthPoints = MaxHealthPoints;
    }

    // Defense
    public void ModifyDefense(float amt)
    {
        Defense += amt;
        if (Defense < 0) Defense = 0;
    }

    public void ScaleDefense(float percent)
    {
        Defense *= percent;
        if (Defense < 0) Defense = 0;
    }

    public void ResetDefense()
    {
        Defense = data.Defense;
    }

    // Attack
    public void ModifyAttack(float amt)
    {
        Attack += amt;
        if (Attack < 0) Attack = 0;
    }

    public void ScaleAttack(float percent)
    {
        Attack *= percent;
        if (Attack < 0) Attack = 0;
    }

    public void ResetAttack()
    {
        Attack = data.Attack;
    }

    // Attack Speed
    public void ModifyAttackSpeed(float amt)
    {
        AttackSpeed += amt;
        if (AttackSpeed < 0) AttackSpeed = 0;
    }

    public void ScaleAttackSpeed(float percent)
    {
        AttackSpeed *= percent;
        if (AttackSpeed < 0) AttackSpeed = 0;
    }

    public void ResetAttackSpeed()
    {
        AttackSpeed = data.AttackSpeed;
    }

    // Speed
    public void ModifySpeed(float amt)
    {
        MovementSpeed += amt;
        if (MovementSpeed < 0) MovementSpeed = 0;
    }

    public void ScaleSpeed(float percent)
    {
        MovementSpeed *= percent;
        if (MovementSpeed < 0) MovementSpeed = 0;

    }

    public void ResetSpeed()
    {
        MovementSpeed = data.MovementSpeed;
    }
    #endregion
}
