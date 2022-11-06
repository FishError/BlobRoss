using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityFieldInfo
{
    public CombatOrganismEntity entity { get; set; }
    public StatusEffect statusEffect { get; set; }

    public EntityFieldInfo(CombatOrganismEntity entity, StatusEffect statusEffect)
    {
        this.entity = entity;
        this.statusEffect = statusEffect;
    }
}

public class FireField : MonoBehaviour
{
    public float damage;
    public float interval;
    public float duration;

    private List<EntityFieldInfo> entitesInField; 

    // Start is called before the first frame update
    IEnumerator Start()
    {
        entitesInField = new List<EntityFieldInfo>();
        yield return StartCoroutine(DestroyField());
    }

    private IEnumerator DestroyField()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            CombatOrganismEntity entity = collision.gameObject.GetComponent<CombatOrganismEntity>();
            StatusEffect burn = new Burn(entity, damage, interval, Mathf.Infinity);
            entity.AddStatusEffect(burn);
            EntityFieldInfo info = new EntityFieldInfo(entity, burn);
            entitesInField.Add(info);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CombatOrganismEntity entity = collision.gameObject.GetComponent<CombatOrganismEntity>();
        if (entity != null)
        {
            EntityFieldInfo info = entitesInField.Find(i => i.entity == entity);
            if (info != null)
            {
                info.statusEffect.End();
            }
        }
    }
}
