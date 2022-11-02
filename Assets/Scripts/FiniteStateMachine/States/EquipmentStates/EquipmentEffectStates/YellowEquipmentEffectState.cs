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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        equipment.StartCoroutine(StopDash());
    }

    public void YellowStateEnter()
    {
        direction = new Vector2(yellowEquipment.player.LastX, yellowEquipment.player.LastY);
        yellowEquipment.player.SetVelocity(yellowEquipment.Velocity, direction);
    }

    public void YellowStatePhysicsUpdate()
    {
        yellowEquipment.player.SetVelocity(yellowEquipment.Velocity, direction);
    }

    public void YellowStateExit()
    {

    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(equipmentData.Duration);
        trailRenderer.emitting = false;
        yellowEquipment.player.StateMachine.ChangeState(yellowEquipment.player.IdleState);
        stateMachine.ChangeState(equipment.IdleState);
        equipment.OnCooldown = true;
    }

}
