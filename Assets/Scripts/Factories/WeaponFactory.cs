using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : MonoBehaviour {

	public static WeaponFactory instance;

	public GameObject[] objects;

	void Awake () {
		instance = this;
	}

	public GameObject Create(WeaponBuilder.weaponType type){
		GameObject go = Instantiate (objects[(int)type]);
		return go;
	}
}
