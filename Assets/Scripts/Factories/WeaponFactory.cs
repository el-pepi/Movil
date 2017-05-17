using UnityEngine;

public class WeaponFactory : MonoBehaviour {

	public static WeaponFactory instance;

	void Awake () {
		instance = this;
	}

	public GameObject Create(WeaponBuilder.weaponType type){
		GameObject go = new GameObject();
        go.name = type.ToString();
		return go;
	}
}
