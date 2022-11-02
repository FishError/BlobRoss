using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipment : Equipment
{
    public Player player { get; set; }

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
    }

    protected override void Start()
    {
        base.Start();
        Duration = equipmentData.Duration;
        Cooldown = equipmentData.DashCooldown;
        Velocity = equipmentData.DashVelocity;
        OnCooldown = false;
    }


    protected override void Update()
    {
        base.Update();
        if (Cooldown > 0 && OnCooldown)
        {
            Cooldown -= Time.deltaTime;
            //Debug.Log(Cooldown);
        }

        if (Cooldown <= 0)
        {
            Cooldown = equipmentData.DashCooldown;
            OnCooldown = false;
        }
    }
}
