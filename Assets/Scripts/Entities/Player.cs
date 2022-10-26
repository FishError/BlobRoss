using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    #region Animation References
    public float LastX { get; set; }
    public float LastY { get; set; }
    #endregion

    #region Player Inputs
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Player Data
    [SerializeField] private PlayerData playerData;
    #endregion

    #region Player Current Stats
    // Health & Defense
    public float MaxHealthPoints { get; set; }
    public float HealthPoints { get; set; }
    public float Defense { get; set; }

    // Attack
    public float Attack { get; set; }
    public float AttackSpeed { get; set; }
    public float CritRate { get; set; }
    public float CritDamage { get; set; }

    // Movement
    public float MovementSpeed { get; set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
    }

    protected override void Start()
    {
        base.Start();
        InputHandler = GetComponent<PlayerInputHandler>();
        StateMachine.Initialize(IdleState);

        MaxHealthPoints = playerData.HealthPoints;
        HealthPoints = MaxHealthPoints;
        Defense = playerData.Defense;
        Attack = playerData.Attack;
        AttackSpeed = playerData.AttackSpeed;
        CritRate = playerData.CritRate;
        CritDamage = playerData.CritDamage;
        MovementSpeed = playerData.MovementSpeed;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    #region Stat Modifier Functions
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
        MaxHealthPoints = playerData.HealthPoints;
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
        Defense = playerData.Defense;
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
        Attack = playerData.Attack;
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
        AttackSpeed = playerData.AttackSpeed;
    }

    // Crit Rate
    public void ModifyCritRate(float amt)
    {
        CritRate += amt;
        if (CritRate < 0) CritRate = 0;
    }

    public void ScaleCritRate(float percent)
    {
        CritRate *= percent;
        if (CritRate < 0) CritRate = 0;
    }

    public void ResetCritRate()
    {
        CritRate = playerData.CritRate;
    }

    // Crit Damage
    public void ModifyCritDamage(float amt)
    {
        CritDamage += amt;
        if (CritDamage < 0) CritDamage = 0;
    }

    public void ScaleCritDamage(float percent)
    {
        CritDamage *= percent;
        if (CritDamage < 0) CritDamage = 0;
    }

    public void ResetCritDamage()
    {
        CritDamage = playerData.CritDamage;
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
        MovementSpeed = playerData.MovementSpeed;
    }
    #endregion
}
