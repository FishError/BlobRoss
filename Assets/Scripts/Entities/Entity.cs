using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region StateMachine
    public FiniteStateMachine StateMachine { get; protected set; }
    #endregion

    #region Animation References
    public Animator Anim { get; protected set; }
    #endregion

    #region Physics References
    public Rigidbody2D rb { get; protected set; }
    public Vector2 CurrentVelocity { get; protected set; }
    protected Vector2 workspace;
    #endregion

    protected virtual void Awake()
    {
        StateMachine = new FiniteStateMachine();
    }

    protected virtual void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
