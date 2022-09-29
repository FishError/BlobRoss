using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }
    #endregion

    #region Animation References
    public Animator Anim { get; private set; }
    public float LastX { get; set; }
    public float LastY { get; set; }
    #endregion

    #region Player Inputs
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Physics References
    public Rigidbody2D rb { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;
    #endregion

    #region Player Data
    [SerializeField] private PlayerData playerData;
    #endregion

    
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float amt)
    {
        workspace.Set(amt, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float amt)
    {
        workspace.Set(CurrentVelocity.x, amt);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }
}
