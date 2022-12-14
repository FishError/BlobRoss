using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipment : Equipment
{
    #region Yellow Equipment Stats
    public float Duration { get; set; }
    public float Velocity { get; set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        IdleState = new YellowEquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new YellowEquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
        EffectState = new YellowEquipmentEffectState(this, StateMachine, equipmentData, "EquipmentEffect");
        color = Color.Yellow;

        // Initialize Yellow Equipment Stats
        Duration = equipmentData.Duration;
        Cooldown = equipmentData.DashCooldown;
        Velocity = equipmentData.DashVelocity;
    }

    protected override void Start()
    {
        base.Start();

    }


    protected override void Update()
    {
        base.Update();
    }

    public override void setUpgrade()
    {
        if (!spaceClickInput && !OnCooldown)
        {
            cooldownTimer = Cooldown;
        }
    }
}
