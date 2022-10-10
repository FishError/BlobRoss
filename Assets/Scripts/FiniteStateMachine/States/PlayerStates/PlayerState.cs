using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;
    protected PlayerData playerData;
    protected float startTime;

    private string animName;

    #region Equipments
    //TODO: replace this with just Equipments[] equipments eventually once red, blue and yellow equipments have animation
    public Transform equipments;
    public Equipment redEquipment {get; private set; }
    // public Equipment blueEquipment {get; private set; }
    // public Equipment yellowEquipment {get; private set; }
    #endregion

    public PlayerState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animName = animName;
        this.equipments = player.gameObject.transform.Find("Equipments");
        this.redEquipment = equipments.GetChild(0).GetComponent<Equipment>();
        // this.blueEquipment = equipments.GetChild(1).GetComponent<Equipment>();
        // this.yellowEquipment = equipments.GetChild(2).GetComponent<Equipment>();
        // Debug.Log(blueEquipment.name);
        // Debug.Log(yellowEquipment.name);
    }

    //Gets called when entered a specific state
    public override void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animName, true);
        startTime = Time.time;
    }

    //Gets called when leaving a specific state
    public override void Exit()
    {
        player.Anim.SetBool(animName, false);
    }

    //Gets called every frame
    public override void LogicUpdate()
    {

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
}
