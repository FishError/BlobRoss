using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    #region States 
    public BossAgroState AgroState { get; protected set; }
    public BossAttackState AttackState { get; protected set; }
    public EnemyDeathState DeathState { get; protected set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        
    }

    protected override void Start()
    {
        base.Start();
    }
}
