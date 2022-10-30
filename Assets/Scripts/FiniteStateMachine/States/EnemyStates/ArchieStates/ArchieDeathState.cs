using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieDeathState : EnemyDeathState
{
    public ArchieDeathState(Enemy enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName)
    {
    }
}
