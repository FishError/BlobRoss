using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CollisionEvent : UnityEvent<Collision2D> { }


public class OnCollisionEnter : MonoBehaviour
{
    public CollisionEvent collisionEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionEvent != null)
            collisionEvent.Invoke(collision);
    }
}
