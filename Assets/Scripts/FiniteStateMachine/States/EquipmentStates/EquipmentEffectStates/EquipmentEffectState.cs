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

    public void PlayEquipmentEffectAudio(int index)
    {
        AudioSource audio = Object.Instantiate(equipment.audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = equipment.gameObject;
        audio.clip = equipment.audioClips[index];
        audio.Play();
    }
}
