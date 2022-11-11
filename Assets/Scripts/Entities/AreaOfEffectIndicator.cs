using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectIndicator : MonoBehaviour
{
    public Collider2D areaOfEffect;
    public float damage;
    public float effectTriggerTime;
    private float timer = 0;

    public GameObject OuterShape;
    public GameObject InnerShape;

    private void Start()
    {
        areaOfEffect = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!areaOfEffect.enabled && timer >= effectTriggerTime)
        {
            areaOfEffect.enabled = true;
            Destroy(gameObject, 0.1f);
        }

        if (timer < effectTriggerTime)
        {
            timer += Time.deltaTime;
            ExpandInnerShape();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.ModifyHealthPoints(-damage);
        }
    }

    private void ExpandInnerShape()
    {
        float x = timer / effectTriggerTime * OuterShape.transform.localScale.x;
        float y = timer / effectTriggerTime * OuterShape.transform.localScale.y;
        float z = timer / effectTriggerTime * OuterShape.transform.localScale.z;
        InnerShape.transform.localScale = new Vector3(x, y, z);
    }
}
