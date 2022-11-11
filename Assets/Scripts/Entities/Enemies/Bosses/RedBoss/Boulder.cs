using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : EnemyProjectile
{
    public GameObject boulderIndicator;
    protected float yPosition;
    protected GameObject createdIndicator;

    protected override void Update()
    {
        base.Update();

        if (gameObject.transform.position.y <= yPosition)
        {
            this.rb.velocity = Vector2.zero;
            this.SetLifeTime(5f);
            this.GetComponent<Animator>().SetBool("goBreak", true);
            Destroy(createdIndicator);
        }
    }

    public void SetYPosition(float yPos)
    {
        yPosition = yPos;
    }

    public void SetIndicator(GameObject obj)
    {
        createdIndicator = obj;
    }
}
