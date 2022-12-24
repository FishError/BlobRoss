using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYellowState : PlayerState
{
    public PlayerYellowState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName) {}

    public override void Enter()
    {
        base.Enter();

        ((YellowEquipmentEffectState)player.equipments[2].EffectState).YellowStateEnter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        ((YellowEquipmentEffectState)player.equipments[2].EffectState).YellowStatePhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

}
