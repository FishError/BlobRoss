using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEquipmentEffectState : EquipmentEffectState
{
    public BlueEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ActivateEffect(equipment.RightClickInput);
    }

    protected override void ActivateEffect(bool equipmentKeyInput)
    {
        base.ActivateEffect(equipmentKeyInput);
        if (equipmentKeyInput && !equipment.OnCooldown){
            if (equipment.XInput != 0 && equipment.YInput != 0)
            {
                SetEffect(equipment.XInput, equipment.YInput);
                equipment.LastX = equipment.XInput;
                equipment.LastY = equipment.YInput;
            }
            else if (equipment.XInput == 0f && equipment.YInput == 0f)
            {
                SetEffect(equipment.LastX, equipment.LastY);
            }
            else if (equipment.XInput == 0f && equipment.YInput != 0f)
            {
                SetEffect(equipment.LastX, equipment.YInput);
                equipment.LastY = equipment.YInput;
            }
            else if (equipment.XInput != 0f && equipment.YInput == 0f)
            {
                SetEffect(equipment.XInput, equipment.LastY);
                equipment.LastX = equipment.XInput;
            }
            return;
        }
    }
}
