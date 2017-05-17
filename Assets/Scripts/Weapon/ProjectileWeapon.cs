using UnityEngine;

public class ProjectileWeapon : Weapon {

	public float fireRate;
	public bool automatic;
    public int ammoType;

	bool pressed;
	float shotTimer;

	public override void OnFirePress ()
	{
		base.OnFirePress ();
		if (automatic == false) {
			Shoot ();
		} else {
			pressed = true;
		}
	}

	public override void OnFireRelease ()
	{
		base.OnFireRelease ();

		pressed = false;
	}

	void Update(){
		if (automatic == false) {
			return;
		}
		Mathf.Clamp (shotTimer -= Time.deltaTime, 0, fireRate);
		if (pressed && shotTimer <= 0) {
			shotTimer = fireRate;
			Shoot ();
		}
	}

	void Shoot(){
		GameObject b = WeaponManager.instance.projectilePools[ammoType].getPooledObject ();
		b.transform.position = transform.position;
		b.transform.rotation = Quaternion.Euler(0,0,180+MathStuff.GetRotationToLook(b.transform.position,(Vector2)transform.position + InputManager.instance.GetAimDirection()));
        b.transform.Translate(Vector3.right * 0.5f, Space.Self);
        b.GetComponent<Rigidbody2D> ().velocity=b.transform.up * 30f;
		b.GetComponent<Projectile> ().Reset ();

        WeaponManager.instance.fireEvent.Invoke();
	}

	public override void OnSwitchOff ()
	{
		base.OnSwitchOff ();

		if (pressed) {
			OnFireRelease ();
		}
	}

	public override void OnSwitchOn ()
	{
		base.OnSwitchOn ();
	}
}
