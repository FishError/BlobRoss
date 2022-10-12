using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    #region Animation References
    public float LastX { get; set; }
    public float LastY { get; set; }
    #endregion

    #region Player Inputs
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Player Data
    [SerializeField] private PlayerData playerData;
    #endregion

    
    protected override void Awake()
    {
        base.Awake();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
    }

    protected override void Start()
    {
        base.Start();
        InputHandler = GetComponent<PlayerInputHandler>();
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
