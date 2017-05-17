using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour {

    [System.NonSerialized]
    public Weapon actualWeapon;

	List<Weapon> weapons;
	int weaponIndex;

    public ObjectPool[] projectilePools;

    public static WeaponManager instance;
    float rot;

    [System.NonSerialized]
    public UnityEvent fireEvent;

    void Awake(){
		instance = this;
		weapons = new List<Weapon> ();

        InputManager.instance.fireDownEvent.AddListener(OnFirePress);
        InputManager.instance.fireUpEvent.AddListener(OnFireRelease);
        InputManager.instance.weaponSwitchEvent.AddListener(SwitchWeapon);
        
        fireEvent = new UnityEvent();
    }

    void Start()
    {

        GetAllWeapons();
    }

	void GetAllWeapons(){
		for (int i = 0; i < (int)WeaponBuilder.weaponType.count; i++) {
			GameObject go = WeaponBuilder.instance.Build ((WeaponBuilder.weaponType)i);
			go.transform.SetParent (PlayerManager.instance.GetPlayer().transform);
            go.transform.localPosition = Vector3.zero;
			weapons.Add (go.GetComponent<Weapon>());
		}
		actualWeapon = weapons [1];
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
