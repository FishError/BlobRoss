using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : Entity
{
    #region States
    public GearIdleState IdleState { get; private set; }
    public GearMoveState MoveState { get; private set; }
    #endregion

    #region Animation References
    public float LastX { get; set; }
    public float LastY { get; set; }
    #endregion

    #region Player Data
    [SerializeField] private GearData gearData;
    #endregion

    
    protected override void Awake()
    {
        base.Awake();
        IdleState = new GearIdleState(this, StateMachine, gearData, "GearIdle");
        MoveState = new GearMoveState(this, StateMachine, gearData, "GearMove");
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
