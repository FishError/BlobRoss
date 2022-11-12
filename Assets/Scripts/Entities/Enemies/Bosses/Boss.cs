using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    #region States 
    public BossAgroState AgroState { get; protected set; }
    public BossAttackState AttackState { get; protected set; }
    #endregion

    public int phase { get; set; }
    public float waitTimeBetweenAttacks { get; set; }

    protected List<BossAttack> Attacks;

    protected override void Start()
    {
        base.Start();
        phase = 1;
        Attacks = new List<BossAttack>();
        StateMachine.Initialize(AgroState);
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
