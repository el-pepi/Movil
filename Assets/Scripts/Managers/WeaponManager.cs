using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour {

    [System.NonSerialized]
    public Weapon actualWeapon;

	List<Weapon> weapons;
	int weaponIndex;

    public ObjectPool[] projectilePools;

    public ObjectPool[] weaponPools;

    public static WeaponManager instance;
    float rot;

    [System.NonSerialized]
    public UnityEvent fireEvent;

    public float weaponTimer = 0;

    int killsTillDrop = 15;

    void Awake(){
		instance = this;
		weapons = new List<Weapon> ();

        InputManager.instance.fireDownEvent.AddListener(OnFirePress);
        InputManager.instance.fireUpEvent.AddListener(OnFireRelease);
        InputManager.instance.weaponSwitchEvent.AddListener(SwitchWeapon);
        GameManager.instance.StateChangeEvent.AddListener(OnGamestateChange);

        fireEvent = new UnityEvent();
    }

    void Start()
    {
        GetAllWeapons();
    }

    void Update()
    {
        if (weaponTimer > 0)
        {
            weaponTimer -= Time.deltaTime;
            if (weaponTimer <= 0)
            {
                SwitchToWeapon(1);
            }
        }
    }

    void OnGamestateChange()
    {
        if(GameManager.instance.state == GameState.Game)
        {
            weaponTimer = 0;
            SwitchToWeapon(1);
        }
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

    public void SwitchToWeapon(int weaponNumber)
    {
        if (weaponNumber < 0 || weaponNumber>=weapons.Count) { return; }

        actualWeapon.OnSwitchOff();

        actualWeapon = weapons[weaponNumber];
        actualWeapon.OnSwitchOn();

        if (weaponNumber != 1)
        {
            weaponTimer = 15f;
        }
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

    public void WeaponDrop(Vector3 position)
    {
        killsTillDrop--;
        if (killsTillDrop <= 0)
        {
            killsTillDrop = Random.Range(40,60);

            GameObject g = weaponPools[Random.Range(0, weaponPools.Length)].getPooledObject();

            g.transform.position = position;
        }
    }
}
