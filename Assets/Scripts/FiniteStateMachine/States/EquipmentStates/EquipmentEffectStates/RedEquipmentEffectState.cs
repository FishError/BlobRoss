using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RedEquipmentEffectState : EquipmentEffectState
{
    public RedEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void Enter()
    {
        base.Enter();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = new Vector2(mousePosition.x - equipment.transform.position.x, mousePosition.y - equipment.transform.position.y);
        direction.Normalize();
        HandleAnimation(direction);
    }


    //TODO: Might move this a level up
    private void HandleAnimation(Vector2 v){
        float angle = Mathf.Atan2(v.y,v.x) * Mathf.Rad2Deg;

        //When using equipment's effect
        if (leftClickInput && !equipment.OnCooldown){
            if (-45f < angle && angle < 45f)
            {
                SetEffect(1,0);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }
            else if ((135f < angle && angle < 180f) || (-180f < angle && angle < -135f))
            {
                SetEffect(-1, 0);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }
            else if (45f <= angle && angle <= 135f)
            {
                SetEffect(0, 1);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }
            else if (-135f <= angle && angle <= -45f)
            {
                SetEffect(0, -1);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }
            equipment.OnCooldown = true;
            return;

        }

        //When no longer using equipment's effect
        else if(xInput == 0f && yInput == 0f){
            SetIdle(equipment.LastX,equipment.LastY);
            stateMachine.ChangeState(equipment.IdleState);
        } else {
            stateMachine.ChangeState(equipment.MoveState);
        }

    }

    protected override void SetEffect(float x, float y)
    {
        base.SetEffect(x, y);

        // Match blue and yellow's equipment current state's direction and red equipment's direction
        for (int i = 0; i < equipment.player.equipments.Length; i++)
        {
            Equipment otherEquipment = equipment.player.equipments[i];
            if (otherEquipment.Anim == null) continue;
            ((EquipmentState)otherEquipment.StateMachine.CurrentState).SetIdle(x, y);
            ((EquipmentState)otherEquipment.StateMachine.CurrentState).SetMove(x, y);
            otherEquipment.RedLastX = x;
            otherEquipment.RedLastY = y;

        }

        // Match player current state's direction and red equipment's direction
        ((PlayerState)equipment.player.StateMachine.CurrentState).SetIdle(x, y);
        ((PlayerState)equipment.player.StateMachine.CurrentState).SetMove(x, y);
        equipment.player.RedLastX = x;
        equipment.player.RedLastY = y;

    }

}
