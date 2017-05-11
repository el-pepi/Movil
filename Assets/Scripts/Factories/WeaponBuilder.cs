using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuilder : MonoBehaviour {

	public static WeaponBuilder instance;

	public enum weaponType{
		pistol,
		submachine,
		count
	};

	void Awake () {
		instance = this;
	}

	public GameObject Build(weaponType type){
		GameObject go = WeaponFactory.instance.Create (type);

		switch (type) {
		case weaponType.pistol:
			ProjectileWeapon pistol = go.AddComponent<ProjectileWeapon> ();
			pistol.automatic = false;
			pistol.weaponName = "Pistol";
			break;

		case weaponType.submachine:
			ProjectileWeapon smg = go.AddComponent<ProjectileWeapon> ();
			smg.automatic = true;
			smg.fireRate = 0.2f;
			smg.weaponName = "smg";
			break;
		}
		return go;
	}
}
