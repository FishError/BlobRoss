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
    public float attackSpeed { get; set; }
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
        attackSpeed = equipmentData.attackSpeed;
        Cooldown = (1 / attackSpeed);
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
            Cooldown = (1 / attackSpeed);
            OnCooldown = false;
        }

        Debug.Log("Damge " + damage);
        Debug.Log("attackSpeed " + attackSpeed);
        Debug.Log("cooldoown " + Cooldown);


    }

    public override void setUpgrade()
    {
        base.setUpgrade();
        Cooldown = (1/attackSpeed);
    }
}
