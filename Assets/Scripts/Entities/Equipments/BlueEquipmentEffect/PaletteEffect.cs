using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaletteEffect : MonoBehaviour
{
    private Vector2 direction;
    private int enemyHitCounter = 0;
    private BlueEquipment equipment;

    private void OnEnable()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize();
        transform.right = -direction;
    }

    private void Start()
    {
        equipment = transform.parent.GetComponent<BlueEquipment>(); 
    }

    private void Update()
    {
        StartCoroutine(ShieldDuration());
        if(enemyHitCounter > equipment.Durability)
        {
            ResetEffectProperties();
            this.gameObject.SetActive(false);
            enemyHitCounter = 0;
        }
    }

    IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(equipment.Duration);
        ResetEffectProperties();
        this.gameObject.SetActive(false);
    }

    public void SetEffectPosition()
    {
        transform.localPosition = direction * 0.25f;
    }

    public void ResetEffectProperties()
    {
        transform.localPosition = new Vector2(0f, 0.085f);
        enemyHitCounter = 0;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Projectiles not implemented yet
        if (other.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            enemyHitCounter++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Enemy makes contact with shield
            enemyHitCounter++;
        }
    }

}
