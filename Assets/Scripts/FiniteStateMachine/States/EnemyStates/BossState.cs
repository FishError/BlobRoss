using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : EnemyState
{
    public BossState(Boss enemy, FiniteStateMachine stateMachine, EnemyData enemyData, string animName) : base(stateMachine, animName)
    {
        
    }
}
