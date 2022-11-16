using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaletteEffect : MonoBehaviour
{
    private Vector2 direction;
    private int enemyHitCounter = 0;
    private BlueEquipment equipment;
    private bool animState;

    private void OnEnable()
    {
        equipment = transform.parent.GetComponent<BlueEquipment>();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize();
        transform.right = -direction;
        animState = false;
        StartCoroutine(ShieldDuration());
    }

    private void Update()
    {
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

    public void EffectIsFinished()
    {
        animState = true;
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
            if (animState)
            {
                enemyHitCounter++;
            }
            else
            {
                MobEnemy enemy = other.gameObject.GetComponent<MobEnemy>();
                enemy.CCState.SetKnockbackValues(-other.GetContact(0).normal * equipment.Knockback, 0.5f);
                enemy.StateMachine.ChangeState(enemy.CCState);
            }
        }
    }

}
