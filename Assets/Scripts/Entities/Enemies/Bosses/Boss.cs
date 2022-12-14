using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Boss : Enemy
{
    #region States 
    public BossBaseIdleState IdleState { get; protected set; }
    public BossBaseAgroState AgroState { get; protected set; }
    public BossBaseAttackState AttackState { get; protected set; }
    public BossBaseDeathState DeathState { get; protected set; }
    #endregion

    public int phase { get; set; }
    public float waitTimeBetweenAttacks { get; set; }

    #region Others
    public bool isDeathStateCalled = false;
    #endregion


    protected List<BossAttack> Attacks;

    protected override void Start()
    {
        base.Start();
        phase = 1;
        Attacks = new List<BossAttack>();
        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
        if (HealthPoints <= 0 && !isDeathStateCalled)
        {
            StateMachine.ChangeState(DeathState);
        }

        if(target.GetComponent<Player>().HealthPoints <= 0)
        {
            SetVelocityX(0);
            SetVelocityY(0);
        }
    }

    protected virtual void UpdateStatsPhase2()
    {
        Attack = ((BossData)data).AttackP2;
        AttackSpeed = ((BossData)data).AttackSpeedP2;
        MovementSpeed = ((BossData)data).MovementSpeedP2;
    }

    public List<BossAttack> AvaliableAttacks()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);
        return Attacks.FindAll(a => !a.OnCooldown() && distance < a.Range);
    }
}
