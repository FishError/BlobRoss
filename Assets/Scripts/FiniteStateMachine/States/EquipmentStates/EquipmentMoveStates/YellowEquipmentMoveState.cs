using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipmentMoveState : EquipmentMoveState
{

    public YellowEquipmentMoveState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (spaceClickInput && !equipment.OnCooldown) {
            stateMachine.ChangeState(equipment.EffectState);
        } 
    }
}
