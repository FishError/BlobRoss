using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState
{
    protected FiniteStateMachine stateMachine;

    protected float startTime;
    protected Vector2 startPosition;

    public EntityState(FiniteStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() 
    {
        startTime = Time.time;
    }

    public abstract void Exit();

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void DoChecks();

    // do something on collision else leave empty
    public virtual void OnCollisionEnter(Collision2D collision)
    {

    }

    public virtual void OnCollisionStay(Collision2D collision)
    {

    }

    public virtual void OnCollisionExit(Collision2D collision)
    {

    }
}
