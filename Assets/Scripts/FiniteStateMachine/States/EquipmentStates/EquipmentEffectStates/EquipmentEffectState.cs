using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentEffectState : EquipmentState
{
    
    public EquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

}
