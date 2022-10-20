using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentState : EntityState
{
    protected Equipment equipment;
    protected EquipmentData equipmentData;
    private string animName;

    #region inputs
    protected float xInput;
    protected float yInput;
    protected bool leftClickInput;
    //Put same for rightClickInput
    //Put same for spaceClickInput
    #endregion

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
    //Put same for RightClickInput
    //Put same for SpaceClickInput

    public EquipmentState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName): base(stateMachine)
    {
        this.equipment = equipment;
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

    public void SetMove(float x, float y)
    {
        equipment.Anim.SetFloat("Horizontal", x);
        equipment.Anim.SetFloat("Vertical", y);
    }

    public void SetIdle(float x, float y)
    {
        equipment.Anim.SetFloat("IdleHorizontal", x);
        equipment.Anim.SetFloat("IdleVertical", y);
        equipment.Anim.SetFloat("offset",0f);
    }

    // Setting the equipment's effect Move Blend tree animation based on player input (direction they're facing)
    protected void SetEffect(float x, float y)
    {
        equipment.Anim.SetFloat("EffectHorizontal", x);
        equipment.Anim.SetFloat("EffectVertical", y);
    }

    protected void SyncAnimations(){
        AnimatorStateInfo currentPlayerAnimState = equipment.transform.parent.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        float offset = currentPlayerAnimState.normalizedTime % 1;
        equipment.Anim.SetFloat("offset",offset+equipment.transitionOffset);
    }

}
