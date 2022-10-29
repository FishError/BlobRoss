using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaletteEffect : MonoBehaviour
{
    private Vector2 direction;

    private void OnEnable()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize();
        transform.right = -direction;
    }

    private void Update()
    {
        StartCoroutine(ShieldDuration());
    }

    IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(3f);
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
        GetComponent<PolygonCollider2D>().enabled = false;

    }

    public void EnableCollider()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
    }

    //The actual projectile is not implemented yet
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            print("hit");
        }

    }

}
