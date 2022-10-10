using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Entity
{
    #region States
    public EquipmentIdleState IdleState { get; private set; }
    public EquipmentMoveState MoveState { get; private set; }
    #endregion

    #region Animation References
    public float LastX { get; set; }
    public float LastY { get; set; }
    #endregion

    #region Equipment Data
    [SerializeField] private EquipmentData equipmentData;
    #endregion

    
    protected override void Awake()
    {
        base.Awake();
        IdleState = new EquipmentIdleState(this, StateMachine, equipmentData, "EquipmentIdle");
        MoveState = new EquipmentMoveState(this, StateMachine, equipmentData, "EquipmentMove");
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
