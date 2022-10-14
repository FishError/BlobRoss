using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentGroundedStates : EquipmentState
{
    protected float xInput;
    protected float yInput;
    protected bool leftClickInput;

    public float XInput{
        get { return xInput; }
        set { xInput = value; } 
    }

    public float YInput{
        get { return yInput; }
        set { yInput = value; } 
    }
    
    public bool LeftClickInput{
        get { return leftClickInput; }
        set { leftClickInput = value; } 
    }

    public EquipmentGroundedStates(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) { }

    public override void Enter()
    {
        base.Enter();
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
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

}
