using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    #region States 
    public BossAgroState AgroState { get; protected set; }
    public BossAttackState AttackState { get; protected set; }
    #endregion

    protected List<BossAttack> Attacks;

    protected override void Start()
    {
        base.Start();
        Attacks = new List<BossAttack>();

        StateMachine.Initialize(AgroState);
    }

    public List<BossAttack> AvaliableAttacks()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);
        return Attacks.FindAll(a => !a.OnCooldown() && distance < a.Range);
    }
}
