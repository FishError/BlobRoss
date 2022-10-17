using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentEffectState : EquipmentGroundedStates
{   
    
    public EquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    // Setting the equipment's effect Move Blend tree animation based on player input (direction they're facing)
    protected void SetEffectDirection(float x, float y)
    {
        equipment.Anim.SetFloat("EffectHorizontal", x);
        equipment.Anim.SetFloat("EffectVertical", y);
    }

    // Setting idle animation on player last input values
    protected void SetIdleAnimation()
    {
        equipment.Anim.SetFloat("IdleHorizontal", equipment.LastX);
        equipment.Anim.SetFloat("IdleVertical", equipment.LastY);
    }

    protected void SetWeaponDirectionUpward()
    {
        if(equipment.LastY == 1)
        {
            equipment.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else
        {
            equipment.GetComponent<SpriteRenderer>().sortingLayerName = "Weapon";
        }
    }
}
