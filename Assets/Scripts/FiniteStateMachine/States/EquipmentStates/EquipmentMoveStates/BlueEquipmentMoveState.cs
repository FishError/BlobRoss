using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEquipmentMoveState : EquipmentMoveState
{
    public BlueEquipmentMoveState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (rightClickInput && !equipment.OnCooldown)
        {
            equipment.OnCooldown = true;
            stateMachine.ChangeState(equipment.EffectState);
        }
    }
}
