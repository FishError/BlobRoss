using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : EnemyProjectile
{
    public float destroyAfterBreakTime;
    public GameObject boulderImpactIndicator;
    protected bool falling;
    protected float yPosition;

    protected override void Update()
    {
        base.Update();

        if (falling && gameObject.transform.position.y <= yPosition)
        {
            SetVelocity(Vector2.zero, 0);
            SetLifeTime(destroyAfterBreakTime);
            GetComponent<Animator>().SetBool("goBreak", true);
            falling = false;
        }
    }

    public void SetTrajectory(GameObject target, float radius)
    {
        SetVelocity(Vector2.up);
        StartCoroutine(SetDownwardTrajectory(target, radius));
    }

    public IEnumerator SetDownwardTrajectory(GameObject target, float radius)
    {
        yield return new WaitForSeconds(1f);
        Vector2 randomPos = (Vector2)target.transform.position + Random.insideUnitCircle * radius;
        transform.position = new Vector2(randomPos.x, transform.position.y);
        yPosition = randomPos.y;

        falling = true;
        SetVelocity(Vector2.down);

        GameObject indicator = Instantiate(boulderImpactIndicator, new Vector2(randomPos.x, randomPos.y - 1f), Quaternion.identity);
        AreaOfEffectIndicator aoeIndicator = indicator.GetComponent<AreaOfEffectIndicator>();
        aoeIndicator.Damage = Damage;
        aoeIndicator.EffectTriggerTime = (transform.position.y - yPosition) / Speed;
    }
}
