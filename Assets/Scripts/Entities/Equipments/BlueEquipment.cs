using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEquipment : Equipment
{
    #region Blue Equipment Stats
    public float Duration { get; set; }
    public int Durability { get; set; }
    public float Knockback { get; set; }
    #endregion

    //TODO Move palette effect to Palette script once new blue equipments are gonna be implemented
    #region Palette 
    public GameObject paletteEffect;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        IdleState = new BlueEquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new BlueEquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
        EffectState = new BlueEquipmentEffectState(this, StateMachine, equipmentData, "EquipmentEffect");
        color = Color.Blue;

        // Initialize Blue Equipment Stats
        Duration = equipmentData.duration;
        Durability = equipmentData.durability;
        Knockback = equipmentData.knockback;
        Cooldown = equipmentData.cooldown;
        Range = equipmentData.range;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
