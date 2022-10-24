using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEquipment : Equipment
{
    protected override void Awake()
    {
        base.Awake();
        IdleState = new BlueEquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new BlueEquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
        EffectState = new BlueEquipmentEffectState(this, StateMachine, equipmentData, "EquipmentEffect");
        color = Color.Blue;
    }
}
