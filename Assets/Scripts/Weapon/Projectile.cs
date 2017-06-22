using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float lifeTime = 3f;

    float actualLifetime;

    void Update()
    {
        actualLifetime -= Time.deltaTime;
        if (actualLifetime <= 0)
        {
            TurnOff();
        }
    }

	public virtual void Reset()
    {
        actualLifetime = lifeTime;
        gameObject.SetActive(true);
    }

    protected void TurnOff()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Enemy")
        {
            return;
        }
        OnHit(col);
    }

    protected virtual void OnHit(Collider2D col)
    {

    }
}
