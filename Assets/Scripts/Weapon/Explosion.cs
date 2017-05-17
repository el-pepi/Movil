using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    float lifeTime = 0.3f;
    float actualLifetime=0.3f;

    void Update()
    {
        actualLifetime -= Time.deltaTime;
        if (actualLifetime <= 0)
        {
            TurnOff();
        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Enemy")
        {
            return;
        }
        col.GetComponent<Character>().TakeDamage(30f);
    }
    void TurnOff()
    {
        gameObject.SetActive(false);
    }
    public void Reset()
    {
        actualLifetime = lifeTime;
        gameObject.SetActive(true);
    }
}
