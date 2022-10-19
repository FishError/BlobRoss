using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEquipment : Equipment
{   
    protected override void Awake()
    {
        base.Awake();
        IdleState = new RedEquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new RedEquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
        EffectState = new RedEquipmentEffectState(this,StateMachine,equipmentData,"EquipmentEffect");
        color = Color.Red;
    }
}
