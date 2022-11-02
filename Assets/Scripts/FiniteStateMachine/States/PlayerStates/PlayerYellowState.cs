using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYellowState : PlayerState
{
    public PlayerYellowState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName) {}

    //private YellowEquipment yellowEquipment;

    public override void Enter()
    {
        base.Enter();
        // yellowEquipment = base.yellowEquipment.transform.GetComponent<YellowEquipment>();

        ((YellowEquipmentEffectState)yellowEquipment.EffectState).YellowStateEnter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        ((YellowEquipmentEffectState)yellowEquipment.EffectState).YellowStatePhysicsUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

}
