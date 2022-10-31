using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityFieldInfo
{
    public CombatEntity entity { get; set; }
    public float timer { get; set; }

    public EntityFieldInfo(CombatEntity entity, float timer)
    {
        this.entity = entity;
        this.timer = timer;
    }
}

public class FireField : MonoBehaviour
{
    public float damage;
    public float interval;
    public float duration;

    private float timer;
    private List<EntityFieldInfo> entitesInField; 

    // Start is called before the first frame update
    IEnumerator Start()
    {
        entitesInField = new List<EntityFieldInfo>();
        yield return StartCoroutine(DestroyField());
    }

    // Update is called once per frame
    void Update()
    {
        foreach(EntityFieldInfo info in entitesInField)
        {
            if (Time.time >= info.timer)
            {
                FieldEffect(info);
            }
        }
    }

    private void FieldEffect(EntityFieldInfo info)
    {
        info.entity.ModifyHealthPoints(-damage);
        info.timer = Time.time + interval;
        print(info.entity.HealthPoints);
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
            EntityFieldInfo info = new EntityFieldInfo(collision.gameObject.GetComponent<CombatEntity>(), Time.time + interval);
            entitesInField.Add(info);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EntityFieldInfo info = entitesInField.Find(i => i.entity == collision.gameObject.GetComponent<CombatEntity>());
            entitesInField.Remove(info);
        }
    }
}
