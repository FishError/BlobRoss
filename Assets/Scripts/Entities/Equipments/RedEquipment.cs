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

    #region Animation Data
    public float originalAttackClipDuration { get; set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        IdleState = new RedEquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new RedEquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
        EffectState = new RedEquipmentEffectState(this,StateMachine,equipmentData,"EquipmentEffect");
        color = Color.Red;

        // Initialize Red Equipment Stats
        damage = equipmentData.Damage;
        attackSpeed = equipmentData.attackSpeed;
        Cooldown = (1 / attackSpeed);

        foreach (AnimationClip clip in Anim.runtimeAnimatorController.animationClips) {
            if (clip.name.ToLower().Contains("effect")){
                originalAttackClipDuration = clip.length;
                break;
            }
        }

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void setUpgrade()
    {
        base.setUpgrade();
        Cooldown = (1/attackSpeed);
        // If the cooldown is faster than the attack animation clip duration
        if (originalAttackClipDuration != 0 && originalAttackClipDuration > Cooldown)
        {
            float attackSpeed = originalAttackClipDuration / Cooldown;
            Anim.SetFloat("AttackSpeed", attackSpeed);
        }
        if (!leftClickInput && !OnCooldown)
        {
            cooldownTimer = Cooldown;
        }
    }
}
