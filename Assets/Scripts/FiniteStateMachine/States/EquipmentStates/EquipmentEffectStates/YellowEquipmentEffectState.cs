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
        yellowEquipment.getPlayer.StateMachine.ChangeState(yellowEquipment.getPlayer.YellowState);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        equipment.StartCoroutine(StopDash());
    }

    public void YellowStateEnter()
    {
        direction = new Vector2(yellowEquipment.getPlayer.LastX, yellowEquipment.getPlayer.LastY);
        yellowEquipment.getPlayer.SetVelocity(yellowEquipment.Velocity, direction);
    }

    public void YellowStatePhysicsUpdate()
    {
        yellowEquipment.getPlayer.SetVelocity(yellowEquipment.Velocity, direction);
    }

    public void YellowStateExit()
    {

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
        if(xInput != 0 || yInput != 0){
            yellowEquipment.getPlayer.StateMachine.ChangeState(yellowEquipment.getPlayer.MoveState);
            foreach(Equipment equipment in yellowEquipment.getPlayer.equipments){
                if(equipment.Anim != null && equipment.Anim.GetCurrentAnimatorStateInfo(0).IsName("Move")){
                    equipment.StateMachine.ChangeState(equipment.MoveState);
                    equipment.Anim.Play("Base Layer.Move",0,0f);
                    equipment.MoveState.SyncAnimations();
                }
            }
            yellowEquipment.StateMachine.ChangeState(equipment.MoveState);

        } else {
            yellowEquipment.getPlayer.StateMachine.ChangeState(yellowEquipment.getPlayer.IdleState);
            foreach(Equipment equipment in yellowEquipment.getPlayer.equipments){
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
