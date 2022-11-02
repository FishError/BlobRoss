using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYellowState : PlayerState
{
    public PlayerYellowState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName) {}

    private YellowEquipment yellowEquipment;
    private Vector2 direction;

    public override void Enter()
    {
        base.Enter();
        yellowEquipment = base.yellowEquipment.transform.GetComponent<YellowEquipment>();

        direction = new Vector2(player.LastX, player.LastY);
        player.SetVelocity(yellowEquipment.Velocity, direction);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocity(yellowEquipment.Velocity, direction);
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
