using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieDeathState : EnemyDeathState
{
    public ArchieDeathState(Archie enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(enemy, stateMachine, enemyData, animName)
    {
    }
}
