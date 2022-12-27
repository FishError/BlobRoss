using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintbrushEffect : MonoBehaviour
{
    private RedEquipment equipment;
    // Start is called before the first frame update
    void OnEnable()
    {
        equipment = transform.parent.gameObject.GetComponent<RedEquipment>();
        equipment.GetComponent<AudioSource>().Play();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.ModifyHealthPoints(-equipment.damage);
        }
    }
}
