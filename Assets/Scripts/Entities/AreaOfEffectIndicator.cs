using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectIndicator : MonoBehaviour
{
    public Collider2D areaOfEffect;
    public float Damage { get; set; }
    public float EffectTriggerTime { get; set; }
    private float timer = 0;

    public GameObject OuterShape;
    public GameObject InnerShape;

    private void Start()
    {
        areaOfEffect = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!areaOfEffect.enabled && timer >= EffectTriggerTime)
        {
            areaOfEffect.enabled = true;
            Destroy(gameObject, 0.1f);
        }

        if (timer < EffectTriggerTime)
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
            player.ModifyHealthPoints(-Damage);
        }
    }

    private void ExpandInnerShape()
    {
        float x = timer / EffectTriggerTime * OuterShape.transform.localScale.x;
        float y = timer / EffectTriggerTime * OuterShape.transform.localScale.y;
        float z = timer / EffectTriggerTime * OuterShape.transform.localScale.z;
        InnerShape.transform.localScale = new Vector3(x, y, z);
    }
}
