using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYellowState : PlayerState
{
    public PlayerYellowState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName) {}

    private YellowEquipment y;
    private float time = 0f;
    private float xAmt = 0f;
    private float yAmt = 0f;
    private Vector2 direction;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("yellowed");
        y = yellowEquipment.transform.GetComponent<YellowEquipment>();
        xAmt = player.LastX;
        yAmt = player.LastY;
        //turn on trail renderer

        direction = new Vector2(player.LastX, player.LastY);
        player.SetVelocity(y.Velocity, direction);

    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("im out");
        //turn off trail renderer
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocity(y.Velocity, direction);

        // Don't update move direction when player dashing
        //if (xAmt > 0 || xAmt < 0)
        //{
        //    SetMoveAnimation(xAmt, yAmt);
        //    //player.LastX = xInput;
        //    //player.LastY = yInput;
        //    player.SetVelocityX(y.Velocity * xAmt);
        //}
        //if (yAmt > 0 || yAmt < 0)
        //{
        //    SetMoveAnimation(xAmt, yAmt);
        //    //player.LastX = xInput;
        //    //player.LastY = yInput;
        //    player.SetVelocityY(y.Velocity * yAmt);
        //}
        //if (xAmt == 0f && yAmt == 0f)
        //{
        //    SetMoveAnimation(xAmt, yAmt);
        //    player.SetVelocityX(y.Velocity * xAmt);
        //    player.SetVelocityY(y.Velocity * yAmt);
        //    stateMachine.ChangeState(player.IdleState);
        //}
        //if (xAmt == 0f && yAmt != 0f)
        //{
        //    SetMoveAnimation(xAmt, yAmt);
        //    //player.LastY = yInput;
        //    player.SetVelocityX(y.Velocity * xAmt);
        //}
        //if (xAmt != 0f && yAmt == 0f)
        //{
        //    SetMoveAnimation(xAmt, yAmt);
        //    //player.LastX = xInput;
        //    player.SetVelocityY(y.Velocity * yAmt);
        //}


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
