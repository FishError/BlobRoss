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

    
        //TODO figure out how to reset offset
        // if(equipment.Anim.GetCurrentAnimatorStateInfo(0).isName("BaseIdle")){
        //     Debug.Log("yes");
        // }
        
    }

    protected void SyncAnimations(){
        AnimatorStateInfo currentPlayerAnimState = equipment.transform.parent.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        float offset = currentPlayerAnimState.normalizedTime % 1;
        equipment.Anim.SetFloat("offset",offset+equipment.transitionOffset);
    }
}
