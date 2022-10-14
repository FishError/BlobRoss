using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEquipmentEffectState : EquipmentEffectState
{

    public RedEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(xInput != 0 || yInput != 0)
        {
            stateMachine.ChangeState(equipment.MoveState);
        }
        equipment.Anim.SetFloat("EffectHorizontal",XInput);
        equipment.Anim.SetFloat("EffectVertical",XInput);

    }



}
