using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipmentEffectState : EquipmentEffectState
{
    private Player player;
    public TrailRenderer trailRenderer { get; private set; }

    public YellowEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {

    }

    public override void Enter()
    {
        base.Enter();
        player = equipment.transform.parent.transform.parent.GetComponent<Player>();

        trailRenderer = equipment.GetComponent<TrailRenderer>();

        trailRenderer.emitting = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        stateMachine.ChangeState(player.YellowState);

        equipment.StartCoroutine(StopDash());
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(equipmentData.Duration);
        trailRenderer.emitting = false;
        stateMachine.ChangeState(player.IdleState);
        stateMachine.ChangeState(equipment.IdleState);
        equipment.OnCooldown = true;
    }

}
