using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Color {
    Red,
    Blue,
    Yellow
}

public class Equipment : Entity
{
    #region States
    public EquipmentIdleState IdleState { get; protected set; }
    public EquipmentMoveState MoveState { get; protected set; }
    public EquipmentEffectState EffectState { get; protected set; }
    #endregion

    #region Animation References
    public float LastX { get; set; }
    public float LastY { get; set; }
    #endregion

    #region Equipment Data
    [SerializeField] protected EquipmentData equipmentData;
    #endregion

    #region Categorize Equipment
    public Color color { get; protected set; }
    #endregion

    #region Equipment Stats 
    public bool OnCooldown { get; set; } 
    public float Cooldown { get; set; } 
    public float Range { get; set; } 
    #endregion
    
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
