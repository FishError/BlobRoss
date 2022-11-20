using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : StatusEffect
{
    public float damage;
    public float interval;
    public float duration;
    public float DOTTimer;

    public Burn(CombatOrganismEntity entity, float damage, float interval, float duration) : base(entity)
    {
        this.damage = damage;
        this.interval = interval;
        this.duration = duration;
    }

    public override void Start()
    {
        base.Start();
        DOTTimer = Time.time + interval;
    }

    public override void Effect()
    {
        if (Time.time >= DOTTimer)
        {
            entity.ModifyHealthPoints(-damage);
            DOTTimer = Time.time + interval;
        }

        if (Time.time >= startTime + duration)
        {
            End();
        }
    }
}
