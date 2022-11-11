using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : CombatEntityData
{
    [Space(10)]
    public float WaitTimeBetweenAttacksP1;

    [Space(15)]
    [Header("Phase 2 Attack Stats")]
    public float AttackP2;
    public float AttackSpeedP2;

    [Header("Phase 2 Movement Stats")]
    public float MovementSpeedP2;

    [Space(10)]
    public float WaitTimeBetweenAttacksP2;
}
