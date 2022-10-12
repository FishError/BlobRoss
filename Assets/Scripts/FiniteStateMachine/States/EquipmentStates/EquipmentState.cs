using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentState : EntityState
{
    protected Equipment equipment;
    protected EquipmentData equipmentData;
    private string animName;

    public EquipmentState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(stateMachine)
    {
        this.equipment = equipment;
        this.stateMachine = stateMachine;
        this.equipmentData = equipmentData;
        this.animName = animName;
    }

    //Gets called when entered a specific state
    public override void Enter()
    {
        DoChecks();
        equipment.Anim.SetBool(animName, true);
        startTime = Time.time;
    }

    //Gets called when leaving a specific state
    public override void Exit()
    {
        equipment.Anim.SetBool(animName, false);
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
