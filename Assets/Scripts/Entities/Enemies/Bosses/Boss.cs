using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : CombatOrganismEntity
{
    #region States 
    // base states that all children are required to have but dont always have use
    // children may also have more than just these states
    public EnemyAgroState AgroState { get; protected set; }
    public EnemyAttackState AttackState { get; protected set; }
    public EnemyDeathState DeathState { get; protected set; }
    #endregion
}
