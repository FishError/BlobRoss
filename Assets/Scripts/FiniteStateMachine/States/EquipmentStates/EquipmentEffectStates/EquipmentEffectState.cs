using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentEffectState : EquipmentState
{
    
    public EquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        if (equipment.Anim == null) return;
        base.LogicUpdate();
    }

    //When using equipment's effect
    protected virtual void ActivateEffect(bool equipmentKeyInput) {

        //When not using equipment's effect
        if (!equipmentKeyInput || equipment.OnCooldown)
        {
            if (equipment.XInput == 0f && equipment.YInput == 0f)
            {
                SetIdle(equipment.LastX, equipment.LastY);
                stateMachine.ChangeState(equipment.IdleState);
            }
            else
            {
                stateMachine.ChangeState(equipment.MoveState);
            }
        }

    }

    public void PlayEquipmentEffectAudio(int index)
    {
        AudioSource audio = Object.Instantiate(equipment.audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = equipment.gameObject;
        audio.clip = equipment.audioClips[index];
        audio.Play();
    }
}
