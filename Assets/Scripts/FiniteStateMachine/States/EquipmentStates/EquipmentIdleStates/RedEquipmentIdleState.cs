using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEquipmentIdleState : EquipmentIdleState
{

    public RedEquipmentIdleState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(leftClickInput){
            stateMachine.ChangeState(equipment.EffectState);
        }
    }
}
