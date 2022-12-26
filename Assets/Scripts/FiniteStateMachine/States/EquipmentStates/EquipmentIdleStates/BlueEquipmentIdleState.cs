using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEquipmentIdleState : EquipmentIdleState
{
    public BlueEquipmentIdleState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {   
        base.LogicUpdate();
        if (equipment.RightClickInput && !equipment.OnCooldown) {
            equipment.OnCooldown = true;
            stateMachine.ChangeState(equipment.EffectState);
        }
    }
}
