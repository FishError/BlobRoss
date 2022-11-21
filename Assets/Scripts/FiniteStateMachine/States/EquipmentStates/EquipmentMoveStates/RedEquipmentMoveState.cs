using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEquipmentMoveState : EquipmentMoveState
{

    public RedEquipmentMoveState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(leftClickInput && !equipment.OnCooldown){
            stateMachine.ChangeState(equipment.EffectState);
        } 
    }
}
