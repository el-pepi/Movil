using UnityEngine;

public class Bullet : Projectile {

	public int hp = 4;
	int actualHp = 4;

    protected override void OnHit(Collider2D col)
    {
        base.OnHit(col);
        col.GetComponent<Character>().TakeDamage(15f);
        ParticleManager.instance.Emit("Blood", transform.position, 1);
		actualHp--;
		if (actualHp <= 0) {
			TurnOff ();
		}
    }
    
	public override void Reset ()
	{
		base.Reset ();
		actualHp = hp;
	}
}
