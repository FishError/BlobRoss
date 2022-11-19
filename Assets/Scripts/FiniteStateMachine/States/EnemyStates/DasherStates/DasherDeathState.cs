using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasherDeathState : EnemyDeathState
{
    public DasherDeathState(Dasher dasher, FiniteStateMachine stateMachine, DasherData data, string animName) : base(dasher, stateMachine, data, animName) { }
}
