using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaletteEffect : MonoBehaviour
{
    private GameObject playerGameObject;
    private BlueEquipment equipment;
    private Vector3 direction;
    private float xMultipler;
    private float yMultipler;
    private int enemyHitCounter = 0;


    private void OnEnable()
    {
        playerGameObject = GameObject.Find("Player");
        equipment = ((BlueEquipment)playerGameObject.GetComponent<Player>().equipments[1]);
        equipment.EffectState.PlayEquipmentEffectAudio(0);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = new Vector3(mousePosition.x - playerGameObject.transform.position.x, mousePosition.y - playerGameObject.transform.position.y,0f);
        direction.Normalize();
        transform.right = -direction;
        transform.position = direction * 0.25f;
        xMultipler = transform.position.x * playerGameObject.transform.localScale.x;
        yMultipler = transform.position.y * playerGameObject.transform.localScale.y;
        StartCoroutine(ShieldDuration());
    }
    
    
    private void Update()
    { 
        transform.position = new Vector3(xMultipler + playerGameObject.transform.position.x, yMultipler + playerGameObject.transform.position.y, 0f);
        if (enemyHitCounter > equipment.Durability)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(equipment.Duration);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyProjectile"))
        {
            enemyHitCounter++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyHitCounter++;
           
            Mob enemy = other.gameObject.GetComponent<Mob>();
            if (enemy != null)
            {
                //enemy.CCState.SetKnockbackValues(-other.GetContact(0).normal * equipment.Knockback, 0.5f);
                enemy.StateMachine.ChangeState(enemy.CCState);
            }
            
        }
    }

}
