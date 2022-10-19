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
    public float transitionOffset;
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
