using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintbrushEffect : MonoBehaviour
{
    private RedEquipment equipment;
    private int animationCounter;

    void OnEnable()
    {
        equipment = transform.parent.gameObject.GetComponent<RedEquipment>();
        animationCounter = 0;
    }

    private void Update()
    {
        AnimatorStateInfo animState = equipment.Anim.GetCurrentAnimatorStateInfo(0);

        if (animState.normalizedTime >= animationCounter)
        {
            SFXManager.Instance.PlayEquipmentRelatedAudio(equipment, 0);
            animationCounter++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.ModifyHealthPoints(-equipment.damage);
            SFXManager.Instance.PlayEnemyRelatedAudio(enemy, enemy.gameObject, 1, 0f, false);
        }
    }
}
