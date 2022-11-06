using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : CombatOrganismEntity
{
    #region States 
    public EnemyAgroState AgroState { get; protected set; }
    public EnemyAttackState AttackState { get; protected set; }
    public EnemyDeathState DeathState { get; protected set; }
    #endregion
}
