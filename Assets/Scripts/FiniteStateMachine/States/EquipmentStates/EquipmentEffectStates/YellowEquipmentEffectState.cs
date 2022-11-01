using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEquipmentEffectState : EquipmentEffectState
{
    private Player player;
    public TrailRenderer trailRenderer { get; private set; }
    private bool isDashing = false;
    private float time = 0f;
    private float offset = 0f;
    private Vector2 baseMoveVec;


    public YellowEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {

    }

    public override void Enter()
    {
        base.Enter();
        player = equipment.transform.parent.transform.parent.GetComponent<Player>();
        //Debug.Log(player);

        trailRenderer = equipment.GetComponent<TrailRenderer>();
        //Debug.Log(trailRenderer);
        trailRenderer.emitting = true;

        //baseMoveVec = player.CurrentVelocity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        stateMachine.ChangeState(player.YellowState);

        equipment.StartCoroutine(StopDash());

        


        //HandleAnimation();


        //Debug.Log("do dash");
        //player.SetVelocity(equipmentData.DashVelocity, player.CurrentVelocity);
        //isDashing = true;

        //equipment.StartCoroutine(StopDash());



        //isDashing = true;

        //Debug.Log(time);
        //Debug.Log(equipmentData.Duration);

        //if (isDashing)
        //{
        //    trailRenderer.emitting = true;
        //    Debug.Log("dddddash");
        //offset += 0.1f;
        //player.SetVelocity(equipmentData.DashVelocity + offset, player.CurrentVelocity);

        //time += Time.deltaTime;

        //if (time > equipmentData.Duration)
        //{
        //    Debug.Log("no more");
        //    isDashing = false;
        //    trailRenderer.emitting = false;
        //    equipment.OnCooldown = true;
        //    time = 0f;
        //    offset = 0f;
        //}
        //}





        //equipment.OnCooldown = true;

        //equipment.StartCoroutine(Dash());


    }


    private void HandleAnimation(){
        //When using effect

        if (xInput > 0 || xInput < 0)
        {
            SetEffect(xInput,yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
            player.SetVelocityX(equipmentData.DashVelocity * xInput);
        }
        if (yInput > 0 || yInput < 0)
        {
            SetEffect(xInput,yInput);
            equipment.LastX = xInput;
            equipment.LastY = yInput;
            player.SetVelocityY(equipmentData.DashVelocity * yInput);

        }
        if (xInput == 0f && yInput == 0f)
        {
            SetEffect(equipment.LastX,equipment.LastY);
        }
        if (xInput == 0f && yInput != 0f)
        {
            SetEffect(equipment.LastX,equipment.LastY);
            equipment.LastY = yInput;
            player.SetVelocityX(equipmentData.DashVelocity * xInput);
        }
        if (xInput != 0f && yInput == 0f)
        {
            SetEffect(equipment.LastX,equipment.LastY);
            equipment.LastX = xInput;
            player.SetVelocityY(equipmentData.DashVelocity * yInput);
        }

        

        //When no longer using yellow equipment's effect
        if(xInput == 0f && yInput == 0f){
            SetIdle(equipment.LastX,equipment.LastY);
            SyncAnimations();
            stateMachine.ChangeState(equipment.IdleState);
        } else {
            SyncAnimations();
            stateMachine.ChangeState(equipment.MoveState);
            //trailRenderer.emitting = false;
        }

    }

    private IEnumerator Dash()
    {
        equipment.OnCooldown = true;
        isDashing = true;
        //Debug.Log("before" + player.rb.velocity);

        //player.rb.velocity = dashingPower * player.rb.velocity;
        //player.SetVelocity(equipmentData.DashVelocity, player.CurrentVelocity);
        float time = 0f;
        float offset = 0f;

        trailRenderer.emitting = true;

        //if (time < equipmentData.Duration)
        //{
        //    Debug.Log("dddddash");
        //    offset += 0.1f;
        //    player.SetVelocity(equipmentData.DashVelocity + offset, player.CurrentVelocity);

        //    time += Time.deltaTime;
        //    Debug.Log(time);
        //}
        //player.rb.velocity = equipmentData.DashVelocity * player.CurrentVelocity;
        //Debug.Log("after" + player.rb.velocity);



        //yield return new WaitForSeconds(equipmentData.Duration);
        trailRenderer.emitting = false;
        isDashing = false;

        //yield return new WaitForSeconds(equipmentData.DashCooldown);
        //equipment.OnCooldown = false;
        yield return null;
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(equipmentData.Duration);
        trailRenderer.emitting = false;
        stateMachine.ChangeState(player.IdleState);
        stateMachine.ChangeState(equipment.IdleState);
        equipment.OnCooldown = true;
        //    isDashing = false;
    }

}
