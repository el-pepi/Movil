using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	Weapon actualWeapon;

	List<Weapon> weapons;
	int weaponIndex;

	public ObjectPool bulletPool;

	public static WeaponManager instance;

	void Awake(){
		instance = this;
		weapons = new List<Weapon> ();

        InputManager.instance.fireDownEvent.AddListener(OnFirePress);
        InputManager.instance.fireUpEvent.AddListener(OnFireRelease);
        InputManager.instance.weaponSwitchEvent.AddListener(SwitchWeapon);

		bulletPool = GetComponent<ObjectPool> ();
    }
	float rot ;
	void Update () {
#if UNITY_EDITOR
        if (Input.GetKeyDown (KeyCode.RightControl)) {
			GetAllWeapons ();
		}
#endif
		if (actualWeapon) {
			rot = MathStuff.GetRotationToLook (actualWeapon.transform.position, (Vector2)actualWeapon.transform.position + InputManager.instance.GetAimDirection ());
			if (rot < 0 || rot>180) {
				actualWeapon.spriteRenderer.flipX = true;
			} else {
				actualWeapon.spriteRenderer.flipX = false;
			}
			actualWeapon.transform.rotation = Quaternion.Euler (0,0,rot);
		}
    }

	void GetAllWeapons(){
		for (int i = 0; i < (int)WeaponBuilder.weaponType.count; i++) {
			GameObject go = WeaponBuilder.instance.Build ((WeaponBuilder.weaponType)i);
			go.transform.SetParent (PlayerManager.instance.GetPlayer().transform);
            go.transform.localPosition = Vector3.zero;
			weapons.Add (go.GetComponent<Weapon>());
		}
		actualWeapon = weapons [0];
        actualWeapon.OnSwitchOn();
	}

    void SwitchWeapon()
    {
        if (weapons.Count == 0)
        {
            return;
        }
        if (actualWeapon)
        {
            actualWeapon.OnSwitchOff();
        }
        weaponIndex++;
        if (weaponIndex >= weapons.Count)
        {
            weaponIndex = 0;
        }
        actualWeapon = weapons[weaponIndex];
        actualWeapon.OnSwitchOn();
    }

    void OnFirePress()
    {
        if (actualWeapon)
        {
            actualWeapon.OnFirePress();
        }
    }

    void OnFireRelease()
    {
        if (actualWeapon)
        {
            actualWeapon.OnFireRelease();
        }
    }
}
