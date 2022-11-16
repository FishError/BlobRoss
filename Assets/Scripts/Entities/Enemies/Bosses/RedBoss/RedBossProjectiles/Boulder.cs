using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : EnemyProjectile
{
    public GameObject boulderImpactIndicator;
    protected bool falling;
    protected float yPosition;

    protected override void Update()
    {
        base.Update();

        if (falling && gameObject.transform.position.y <= yPosition)
        {
            rb.velocity = Vector2.zero;
            SetLifeTime(5f);
            GetComponent<Animator>().SetBool("goBreak", true);
        }
    }

    public void SetTrajectory(GameObject target, float radius)
    {
        SetVelocity(Vector2.up, 20f);
        StartCoroutine(SetDownwardTrajectory(target, radius));
    }

    public IEnumerator SetDownwardTrajectory(GameObject target, float radius)
    {
        yield return new WaitForSeconds(1f);
        Vector2 randomPos = (Vector2)target.transform.position + Random.insideUnitCircle * radius;
        transform.position = new Vector2(randomPos.x, transform.position.y);
        yPosition = randomPos.y;

        falling = true;
        SetVelocity(Vector2.down, 20f);

        GameObject indicator = Instantiate(boulderImpactIndicator, new Vector2(randomPos.x, randomPos.y - 1f), Quaternion.identity);
        AreaOfEffectIndicator aoeIndicator = indicator.GetComponent<AreaOfEffectIndicator>();
        aoeIndicator.damage = damage;
        aoeIndicator.effectTriggerTime = (transform.position.y - yPosition) / 20f;
    }
}
