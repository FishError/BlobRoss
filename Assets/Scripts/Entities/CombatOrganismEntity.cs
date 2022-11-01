using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatOrganismEntity : Entity
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
    public virtual void ModifyMaxHealthPoints(float amt)
    {
        MaxHealthPoints += amt;
        if (MaxHealthPoints < 0) MaxHealthPoints = 0;
        ModifyHealthPoints(amt);
    }

    public virtual void ScaleMaxHealthPoints(float percent)
    {
        MaxHealthPoints *= percent;
        if (MaxHealthPoints < 0) MaxHealthPoints = 0;
        ModifyHealthPoints(MaxHealthPoints * (percent - 1f));
    }

    public virtual void ResetMaxHealthPoints()
    {
        MaxHealthPoints = data.HealthPoints;
        if (HealthPoints > MaxHealthPoints) ResetHealthPoints();
    }

    public virtual void ModifyHealthPoints(float amt)
    {
        HealthPoints += amt;
        if (HealthPoints < 0) HealthPoints = 0;
        else if (HealthPoints > MaxHealthPoints) HealthPoints = MaxHealthPoints;
        print(gameObject.name + " HP: " + MaxHealthPoints + "/" + HealthPoints);
    }

    public virtual void ScaleHealthPoints(float percent)
    {
        HealthPoints *= percent;
        if (HealthPoints < 0) HealthPoints = 0;
        else if (HealthPoints > MaxHealthPoints) HealthPoints = MaxHealthPoints;
    }

    public virtual void ResetHealthPoints()
    {
        HealthPoints = MaxHealthPoints;
    }

    // Defense
    public virtual void ModifyDefense(float amt)
    {
        Defense += amt;
        if (Defense < 0) Defense = 0;
    }

    public virtual void ScaleDefense(float percent)
    {
        Defense *= percent;
        if (Defense < 0) Defense = 0;
    }

    public virtual void ResetDefense()
    {
        Defense = data.Defense;
    }

    // Attack
    public virtual void ModifyAttack(float amt)
    {
        Attack += amt;
        if (Attack < 0) Attack = 0;
    }

    public virtual void ScaleAttack(float percent)
    {
        Attack *= percent;
        if (Attack < 0) Attack = 0;
    }

    public virtual void ResetAttack()
    {
        Attack = data.Attack;
    }

    // Attack Speed
    public virtual void ModifyAttackSpeed(float amt)
    {
        AttackSpeed += amt;
        if (AttackSpeed < 0) AttackSpeed = 0;
    }

    public virtual void ScaleAttackSpeed(float percent)
    {
        AttackSpeed *= percent;
        if (AttackSpeed < 0) AttackSpeed = 0;
    }

    public virtual void ResetAttackSpeed()
    {
        AttackSpeed = data.AttackSpeed;
    }

    // Speed
    public virtual void ModifySpeed(float amt)
    {
        MovementSpeed += amt;
        if (MovementSpeed < 0) MovementSpeed = 0;
    }

    public virtual void ScaleSpeed(float percent)
    {
        MovementSpeed *= percent;
        if (MovementSpeed < 0) MovementSpeed = 0;

    }

    public virtual void ResetSpeed()
    {
        MovementSpeed = data.MovementSpeed;
    }
    #endregion
}
