using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TriggerEvent : UnityEvent<Collider2D> { }


public class OnTriggerEnter : MonoBehaviour
{
    public TriggerEvent triggerEvent;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (triggerEvent != null)
            triggerEvent.Invoke(collider);
    }
}
