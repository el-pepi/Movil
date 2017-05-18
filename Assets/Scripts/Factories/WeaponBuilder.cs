using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuilder : MonoBehaviour {

	public static WeaponBuilder instance;

	public enum weaponType{
		pistol,
		submachine,
        rocket,
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
                pistol.ammoType = 0;
			break;

		case weaponType.submachine:
			ProjectileWeapon smg = go.AddComponent<ProjectileWeapon> ();
			smg.automatic = true;
			smg.fireRate = 0.1f;
			smg.weaponName = "SMG";
                smg.ammoType = 0;
                break;
        case weaponType.rocket:
            ProjectileWeapon rl = go.AddComponent<ProjectileWeapon>();
            rl.automatic = true;
            rl.fireRate = 0.25f;
            rl.weaponName = "Rocket launcher";
                rl.ammoType = 1;
                break;
        }
		return go;
	}
}
