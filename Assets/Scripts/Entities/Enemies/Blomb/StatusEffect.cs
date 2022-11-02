using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    protected CombatOrganismEntity entity;
    protected float startTime;

    public StatusEffect(CombatOrganismEntity entity)
    {
        this.entity = entity;
    }

    public virtual void Start()
    {
        startTime = Time.time;
    }

    public virtual void End()
    {
        entity.statusEffects.Remove(this);
    }

    public abstract void Effect();


}
