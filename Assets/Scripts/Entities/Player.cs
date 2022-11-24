using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CombatOrganismEntity
{
    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerYellowState YellowState { get; private set; }
    public PlayerCCState CCState { get; private set; }
    public PlayerDeathState DeathState { get; private set; }
    #endregion

    #region Equipments
    public Transform equipmentsContainer;
    public Equipment[] equipments = new Equipment[3];
    #endregion

    #region Animation References
    public float LastX { get; set; }
    public float LastY { get; set; }
    public float RedLastX { get; set; }
    public float RedLastY { get; set; }
    #endregion

    #region Player Inputs
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Player Current Stats
    // Crit
    public float CritRate { get; set; }
    public float CritDamage { get; set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        IdleState = new PlayerIdleState(this, StateMachine, (PlayerData)data, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, (PlayerData)data, "Move");
        YellowState = new PlayerYellowState(this, StateMachine, (PlayerData)data, "Move");
        CCState = new PlayerCCState(this, StateMachine, (PlayerData)data, "Idle");
        DeathState = new PlayerDeathState(this, StateMachine, (PlayerData)data, "Death");
    }

    protected override void Start()
    {
        base.Start();
        InputHandler = GetComponent<PlayerInputHandler>();

        equipmentsContainer = gameObject.transform.Find("Equipments");
        equipments[0] = equipmentsContainer.GetChild(0).GetComponent<RedEquipment>();;
        equipments[1] = equipmentsContainer.GetChild(1).GetComponent<BlueEquipment>();
        equipments[2] = equipmentsContainer.GetChild(2).GetComponent<YellowEquipment>();
        StateMachine.Initialize(IdleState);

        MaxHealthPoints = data.HealthPoints;
        HealthPoints = MaxHealthPoints;
        Defense = data.Defense;
        Attack = data.Attack;
        AttackSpeed = data.AttackSpeed;
        CritRate = ((PlayerData)data).CritRate;
        CritDamage = ((PlayerData)data).CritDamage;
        MovementSpeed = data.MovementSpeed;
        LastX = 0;
        LastY = -1;
    }

    protected override void Update()
    {
        base.Update();
        if (HealthPoints <= 0)
        {
            StateMachine.ChangeState(DeathState);
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    #region Stat Modifier Functions
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
        CritRate = ((PlayerData)data).CritRate;
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
        CritDamage = ((PlayerData)data).CritDamage;
    }
    #endregion
}
