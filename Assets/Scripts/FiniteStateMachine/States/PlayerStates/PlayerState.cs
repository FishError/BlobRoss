using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;
    protected PlayerData playerData;
    protected float startTime;

    private string animName;

    #region Gears
    //TODO: replace this with just Gears[] gears eventually once red, blue and yellow gears have animation
    public Transform gears;
    public Gear redGear {get; private set; }
    // public Gear blueGear {get; private set; }
    // public Gear yellowGear {get; private set; }
    #endregion

    public PlayerState(Player player, FiniteStateMachine stateMachine, PlayerData playerData, string animName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animName = animName;
        this.gears = player.gameObject.transform.Find("Gears");
        this.redGear = gears.GetChild(0).GetComponent<Gear>();
        // this.blueGear = gears.GetChild(1).GetComponent<Gear>();
        // this.yellowGear = gears.GetChild(2).GetComponent<Gear>();
        Debug.Log(redGear.name);
        // Debug.Log(blueGear.name);
        // Debug.Log(yellowGear.name);
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
