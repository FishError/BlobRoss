using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public abstract void Move();

    public abstract void Attack();

    public abstract void Death();

    public abstract void TakeDamage();



}
