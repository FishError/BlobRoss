using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    protected float _hp;
    protected float _speed;
    protected float _attack;

    public float HP { get; set; }
    public float Speed { get; set; }
    
    public float AttackDamage { get; set; }

    public abstract void Move();

    public abstract void Attack();



}
