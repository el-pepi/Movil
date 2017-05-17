using UnityEngine;

public class Bullet : Projectile {

    protected override void OnHit(Collider2D col)
    {
        base.OnHit(col);
        col.GetComponent<Character>().TakeDamage(10f);
        ParticleManager.instance.Emit("Blood", transform.position, 1);
        TurnOff();
    }
    
}
