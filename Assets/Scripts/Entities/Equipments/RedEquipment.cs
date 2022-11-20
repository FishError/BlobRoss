using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.EventSystems.EventTrigger;

public class RedEquipment : Equipment
{
    #region Red Equipment Stats
    public float damage { get; set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        IdleState = new RedEquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new RedEquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
        EffectState = new RedEquipmentEffectState(this,StateMachine,equipmentData,"EquipmentEffect");
        color = Color.Red;
    }

    protected override void Start()
    {
        base.Start();
        damage = equipmentData.Damage;
        Cooldown = (1 / equipmentData.attackSpeed);
        OnCooldown = false;
    }
    protected override void Update()
    {  
        base.Update();
        if (Cooldown > 0 && OnCooldown)
        {
            Cooldown -= Time.deltaTime;
        }

        if (Cooldown <= 0)
        {
            Cooldown = (1 / equipmentData.attackSpeed);
            OnCooldown = false;
        }


    }
}
