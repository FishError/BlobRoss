using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentState : EntityState
{
    #region GameObjects
    protected GameObject playerGameObject;
    #endregion

    protected Equipment equipment;
    protected EquipmentData equipmentData;
    private string animName;

    #region inputs
    protected float xInput;
    protected float yInput;
    protected bool leftClickInput;
    protected bool rightClickInput;
    protected bool spaceClickInput;
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

    public bool RightClickInput
    {
        get { return rightClickInput; }
        set { rightClickInput = value; }
    }
    //Put same for SpaceClickInput
    public bool SpaceClickInput
    {
        get { return spaceClickInput; }
        set { spaceClickInput = value; }
    }

    public EquipmentState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName): base(stateMachine)
    {
        this.equipment = equipment;
        this.equipmentData = equipmentData;
        this.animName = animName;
        this.playerGameObject = equipment.transform.parent.parent.gameObject;
    }

    //Gets called when entered a specific state
    public override void Enter()
    {   
        if(equipment.Anim == null) return;
        DoChecks();
        equipment.Anim.SetBool(animName, true);
    }

    //Gets called when leaving a specific state
    public override void Exit()
    {
        if(equipment.Anim == null) return;
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
    }

    protected void SetEffect(float x, float y)
    {
        equipment.Anim.SetFloat("EffectHorizontal", x);
        equipment.Anim.SetFloat("EffectVertical", y);
    }

    public void SyncAnimations(){
        AnimatorStateInfo currentPlayerAnimState = playerGameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        float offset = currentPlayerAnimState.normalizedTime % 1;
        equipment.Anim.SetFloat("offset",offset);
    }

}
