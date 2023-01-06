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

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (equipment.colorDropletStack == 0)
        {
            ((RedEquipment)equipment).originalAttackClipDuration = equipment.Anim.GetCurrentAnimatorStateInfo(0).length;
        }
        setAttackDirection();
        equipment.OnCooldown = true;
        if (equipment.XInput == 0f && equipment.YInput == 0f)
        {
            SetIdle(equipment.LastX, equipment.LastY);
            stateMachine.ChangeState(equipment.IdleState);
        }
        else
        {
            stateMachine.ChangeState(equipment.MoveState);
        }


    }

    private void setAttackDirection ()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = new Vector2(mousePosition.x - equipment.transform.position.x, mousePosition.y - equipment.transform.position.y);
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (-45f < angle && angle < 45f)
        {
            SetEffect(1,0);
            equipment.LastX = direction.x;
            equipment.LastY = direction.y;
        }
        else if (45f <= angle && angle <= 135f)
        {
            SetEffect(0, 1);
            equipment.LastX = direction.x;
            equipment.LastY = direction.y;
        }
        else if ((135f < angle && angle < 180f) || (-180f < angle && angle < -135f))
        {
            SetEffect(-1, 0);
            equipment.LastX = direction.x;
            equipment.LastY = direction.y;
        }
        else if (-135f <= angle && angle <= -45f)
        {
            SetEffect(0, -1);
            equipment.LastX = direction.x;
            equipment.LastY = direction.y;
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

        // Match player's current state's direction and red equipment's direction
        ((PlayerState)equipment.player.StateMachine.CurrentState).SetIdle(x, y);
        ((PlayerState)equipment.player.StateMachine.CurrentState).SetMove(x, y);
        equipment.player.RedLastX = x;
        equipment.player.RedLastY = y;
    }
}
