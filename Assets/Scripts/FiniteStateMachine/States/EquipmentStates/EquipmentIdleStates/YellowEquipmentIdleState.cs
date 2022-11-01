using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipmentIdleState : EquipmentIdleState
{

    public YellowEquipmentIdleState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(spaceClickInput && !equipment.OnCooldown)
        {
            //Debug.Log("here");
            //equipment.OnCooldown = true;
            stateMachine.ChangeState(equipment.EffectState);
        }
    }
}
