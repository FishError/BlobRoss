using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipmentEffectState : EquipmentEffectState
{
    public YellowEquipment yellowEquipment;
    public Vector2 direction;
    public TrailRenderer trailRenderer { get; private set; }

    public YellowEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {
        yellowEquipment = (YellowEquipment)equipment;
    }

    public override void Enter()
    {
        base.Enter();
        trailRenderer = equipment.GetComponent<TrailRenderer>();
        trailRenderer.emitting = true;
        yellowEquipment.player.StateMachine.ChangeState(yellowEquipment.player.YellowState);
    }

    public void YellowStateEnter()
    {
        direction = new Vector2(yellowEquipment.player.LastX, yellowEquipment.player.LastY);
        yellowEquipment.player.SetVelocity(yellowEquipment.Velocity, direction);
        SFXManager.Instance.PlayEquipmentBasedAudio(yellowEquipment, 2);
    }

    public void YellowStateExit()
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        equipment.StartCoroutine(StopDash());
    }

    public void YellowStatePhysicsUpdate()
    {
        yellowEquipment.player.SetVelocity(yellowEquipment.Velocity, direction);
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(equipmentData.Duration);
        trailRenderer.emitting = false;
        handleOtherEntityAnimations();
        equipment.OnCooldown = true;
    }

    private void handleOtherEntityAnimations()
    {
        //TODO animation controller refactor here
        if(equipment.XInput != 0 || equipment.YInput != 0){
            yellowEquipment.player.StateMachine.ChangeState(yellowEquipment.player.MoveState);
            foreach(Equipment equipment in yellowEquipment.player.equipments){
                if(equipment.Anim != null && equipment.Anim.GetCurrentAnimatorStateInfo(0).IsName("Move")){
                    equipment.StateMachine.ChangeState(equipment.MoveState);
                    equipment.Anim.Play("Base Layer.Move",0,0f);
                    equipment.MoveState.SyncAnimations();
                }
            }
            yellowEquipment.StateMachine.ChangeState(equipment.MoveState);

        } else {
            yellowEquipment.player.StateMachine.ChangeState(yellowEquipment.player.IdleState);
            foreach(Equipment equipment in yellowEquipment.player.equipments){
                if(equipment.Anim != null && equipment.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
                    equipment.StateMachine.ChangeState(equipment.IdleState);
                    equipment.Anim.Play("Base Layer.Idle",0,0f);
                    equipment.IdleState.SyncAnimations();
                }
            }
            yellowEquipment.StateMachine.ChangeState(equipment.IdleState);
        }
    }

}
