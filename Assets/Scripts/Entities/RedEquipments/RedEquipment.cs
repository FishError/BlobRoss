using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEquipment : Equipment
{   
    protected override void Awake()
    {
        base.Awake();
        color = "red";
    }
}
