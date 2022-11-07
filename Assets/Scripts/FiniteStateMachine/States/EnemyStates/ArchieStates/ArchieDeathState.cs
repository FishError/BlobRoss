using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieDeathState : EnemyDeathState
{
    public ArchieDeathState(Archie archie, FiniteStateMachine stateMachine, ArchieData data, string animName) : base(archie, stateMachine, data, animName)
    {
    }
}
