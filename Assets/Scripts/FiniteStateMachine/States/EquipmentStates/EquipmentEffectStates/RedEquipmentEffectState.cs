using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RedEquipmentEffectState : EquipmentEffectState
{

    public RedEquipmentEffectState(Equipment equipment, FiniteStateMachine stateMachine, EquipmentData equipmentData, string animName) : base(equipment, stateMachine, equipmentData, animName) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        Debug.Log("You inflicted 100 attack damage");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = new Vector2(mousePosition.x - equipment.transform.position.x, mousePosition.y - equipment.transform.position.y);
        direction.Normalize();
        //Debug.Log(direction);
        HandleAnimation(direction);
        /*Put any red equipment related effects here:
            DamageInfliction();
            AddingColor();
        */

    }

    //TODO: Might move this a level up
    private void HandleAnimation(Vector2 v){
        float angle = Mathf.Atan2(v.y,v.x) * Mathf.Rad2Deg;
        //When using equipment's effect
        if (leftClickInput){
            if (-45f < angle && angle < 45f)
            {
                SetEffect(1,0);
                equipment.player.IdleState.SetIdle(1,0);
                equipment.player.equipments[1].IdleState.SetIdle(1, 0);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }
            else if ((135f < angle && angle < 180f) || (-180f < angle && angle < -135f))
            {
                SetEffect(-1,0);
                equipment.player.IdleState.SetIdle(-1,0);
                equipment.player.equipments[1].IdleState.SetIdle(-1, 0);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }
            else if (45f <= angle && angle <= 135f)
            {
                SetEffect(0,1);
                equipment.player.IdleState.SetIdle(0,1);
                equipment.player.equipments[1].IdleState.SetIdle(0, 1);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }
            else if (-135f <= angle && angle <= -45f)
            {
                SetEffect(0,-1);
                equipment.player.IdleState.SetIdle(0,-1);
                equipment.player.equipments[1].IdleState.SetIdle(0, -1);
                equipment.LastX = v.x;
                equipment.LastY = v.y;
            }

        }

        //When no longer using equipment's effect
        else if(xInput == 0f && yInput == 0f){
            SetIdle(equipment.LastX,equipment.LastY);
            stateMachine.ChangeState(equipment.IdleState);
        } else {
            stateMachine.ChangeState(equipment.MoveState);
        }

    }

}
