using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipment : Equipment
{
    public Player getPlayer { get; set; }

    #region Yellow Equipment Stats
    public float Duration { get; set; }
    public float Velocity { get; set; }
    #endregion

    float tempCooldown;

    protected override void Awake()
    {
        base.Awake();
        IdleState = new YellowEquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new YellowEquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
        EffectState = new YellowEquipmentEffectState(this, StateMachine, equipmentData, "EquipmentEffect");
        color = Color.Yellow;

        Duration = equipmentData.Duration;
        Cooldown = equipmentData.DashCooldown;
        Velocity = equipmentData.DashVelocity;
        OnCooldown = false;

        tempCooldown = equipmentData.DashCooldown;
    }

    protected override void Start()
    {
        base.Start();

    }


    protected override void Update()
    {
        base.Update();
        if (tempCooldown > 0 && OnCooldown)
        {
            tempCooldown -= Time.deltaTime;
        }

        if (tempCooldown <= 0)
        {
            tempCooldown = Cooldown;
            OnCooldown = false;
        }
    }
}
