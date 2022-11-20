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
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            //enemy.ModifyHealthPoints(-equipment.damage);
            Debug.Log("Enemy HP: " +  enemy.HealthPoints);
            //enemy.StateMachine.ChangeState(enemy.CCState);

        }
    }
}
