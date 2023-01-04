using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;
    protected PlayerData playerData;
    protected float xInput;
    protected float yInput;
    protected bool leftClick;

    protected string animName;


    public PlayerState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(stateMachine)
    {
        this.player = player;
        this.playerData = playerData;
        this.animName = animName;
    }

    //Gets called when entered a specific state
    public override void Enter()
    {
        base.Enter();
        DoChecks();
        player.Anim.SetBool(animName, true);
        startPosition = player.transform.position;
    }

    //Gets called when leaving a specific state
    public override void Exit()
    {
        player.Anim.SetBool(animName, false);
    }

    //Gets called every frame
    public override void LogicUpdate()
    {
        // Setting x,y and equipment inputs for each equipment's states 
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        // To ensure that player faces the same direction as the direction the paintbrush swings
        leftClick = player.InputHandler.leftClickInput;

        foreach (Equipment equipment in player.equipments)
        {
            equipment.XInput = xInput;
            equipment.YInput = yInput;
            equipment.LeftClickInput = player.InputHandler.leftClickInput;
            equipment.RightClickInput = player.InputHandler.rightClickInput;
            equipment.SpaceClickInput = player.InputHandler.spaceClickInput;
        }

    }

    //Gets called every FixedUpdate
    public override void PhysicsUpdate()
    {
        DoChecks();
    }

    //Check for Walls/Grounded etc
    public override void DoChecks()
    {

    }

    public void SetMove(float x, float y)
    {
        player.Anim.SetFloat("Horizontal", x);
        player.Anim.SetFloat("Vertical", y);
    }

    public void SetIdle(float x, float y)
    {
        player.Anim.SetFloat("IdleHorizontal", x);
        player.Anim.SetFloat("IdleVertical", y);
    }
}
