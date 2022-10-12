using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, FiniteStateMachine stateMachine) : base(enemy, stateMachine) { }
}
