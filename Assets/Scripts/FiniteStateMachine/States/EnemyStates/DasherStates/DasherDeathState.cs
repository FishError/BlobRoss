using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherDeathState : EnemyDeathState
{
    public DasherDeathState(Dasher enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName) { }
}
