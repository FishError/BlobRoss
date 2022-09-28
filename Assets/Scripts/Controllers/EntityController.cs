using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _attack;
    protected float _curHp;

    public float MaxHP { get; set; }
    public float CurHP { get; set; }
    public float Speed { get; set; }
    public float AttackDamage { get; set; }

    public void Start()
    {
        _curHp = _maxHp;
    }

    public abstract void Move();

    public abstract void Attack();

    public abstract void TakeDamage();

    public abstract void Death();





}
