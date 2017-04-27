using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon {

	public ObjectPool bulletPool;

	public float fireRate;
	public bool automatic;

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
		Mathf.Clamp (shotTimer -= Time.deltaTime, 0, fireRate);
		if (pressed && shotTimer <= 0) {
			shotTimer = fireRate;
			Shoot ();
		}
	}

	void Shoot(){
		print ("Bang");
	}

	public override void OnSwitchOff ()
	{
		base.OnSwitchOff ();

		if (pressed) {
			OnFireRelease ();
		}
		print ("Switched OFF " + weaponName);
	}

	public override void OnSwitchOn ()
	{
		base.OnSwitchOn ();

		print ("Switch ON " + weaponName);
	}
}
