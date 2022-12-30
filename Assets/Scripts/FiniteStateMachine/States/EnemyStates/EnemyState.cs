using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    protected Animator animator;
    protected string animName;
    protected float distance;

    public EnemyState(FiniteStateMachine stateMachine, Animator animator, string animName) : base(stateMachine)
    {
        this.animator = animator;
        this.animName = animName;
    }

    public override void DoChecks()
    {

    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
        animator.SetBool(animName, true);
    }

    public override void Exit()
    {
        animator.SetBool(animName, false);
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }

    public void PlayEnemyAudio(Enemy enemy, GameObject parentObject, int index, float delay, bool playAfterDestroy)
    {
        AudioSource audio = Object.Instantiate(enemy.audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = parentObject;
        audio.GetComponent<SFXDestroyer>().playAfterDestroy = playAfterDestroy;
        audio.clip = enemy.audioClips[index];
        audio.PlayDelayed(delay);
    }
}
