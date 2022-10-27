using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEquipmentEffectState : EquipmentEffectState
{
    public BlueEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName)
    {
    }


    public override void Enter()
    {
        base.Enter();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ActivateEffect();
    }

    private void ActivateEffect()
    {
        //When using effect
        Debug.Log("Shield Up");
        equipment.transform.GetChild(0).gameObject.SetActive(true);

        //When no longer using blue equipment's effect
        if (xInput == 0f && yInput == 0f)
        {
            SetIdle(equipment.LastX, equipment.LastY);
            //SyncAnimations();
            stateMachine.ChangeState(equipment.IdleState);
        }
        else
        {
            //SyncAnimations();
            stateMachine.ChangeState(equipment.MoveState);
        }

    }
}
