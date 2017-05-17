using UnityEngine;

public class Rocket : Projectile {
    public GameObject explosionTrigger;

    protected override void OnHit(Collider2D col)
    {
        base.OnHit(col);
        col.GetComponent<Character>().TakeDamage(35f);
        ParticleManager.instance.Emit("Explosion", transform.position, 1);
        Instantiate<GameObject>(explosionTrigger, transform.position, Quaternion.identity);
        TurnOff();
    }
}
