using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;
    protected PlayerData playerData;
    protected float xInput;
    protected float yInput;

    protected string animName;

    #region Equipments
    //TODO: replace this with just Equipments[] equipments eventually once red, blue and yellow equipments have animation
    public Transform equipments;
    public RedEquipment redEquipment {get; private set; }
    public BlueEquipment blueEquipment { get; private set; }
    // public Equipment yellowEquipment {get; private set; }
    #endregion

    public PlayerState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName) : base(stateMachine)
    {
        this.player = player;
        this.playerData = playerData;
        this.animName = animName;
        //Change to find children
        this.equipments = player.gameObject.transform.Find("Equipments");
        this.redEquipment = equipments.GetChild(0).GetComponent<RedEquipment>();
        this.blueEquipment = equipments.GetChild(1).GetComponent<BlueEquipment>();
        // this.yellowEquipment = equipments.GetChild(2).GetComponent<Equipment>();
        // Debug.Log(blueEquipment.name);
        // Debug.Log(yellowEquipment.name);
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
 
        redEquipment.IdleState.XInput = xInput;
        redEquipment.IdleState.YInput = yInput;
        redEquipment.IdleState.LeftClickInput = player.InputHandler.leftClickInput;

        redEquipment.MoveState.XInput = xInput;
        redEquipment.MoveState.YInput = yInput;
        redEquipment.MoveState.LeftClickInput = player.InputHandler.leftClickInput;

        redEquipment.EffectState.XInput = xInput;
        redEquipment.EffectState.YInput = yInput;
        redEquipment.EffectState.LeftClickInput = player.InputHandler.leftClickInput;
        
        //TODO: copy 9 lines above for yellow & blue

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

     public void SetMoveAnimation(float x, float y)
    {
        player.Anim.SetFloat("Horizontal", x);
        player.Anim.SetFloat("Vertical", y);
    }

    public void SetIdleAnimation(float x, float y)
    {
        player.Anim.SetFloat("IdleHorizontal", x);
        player.Anim.SetFloat("IdleVertical", y);
    }
}
