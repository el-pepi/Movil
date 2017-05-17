using UnityEngine;

public class Weapon : MonoBehaviour {

	public string weaponName;
    

	void Awake(){
		OnSwitchOff ();
	}

	public virtual void OnFirePress(){
	}
	public virtual void OnFireRelease(){
	}
	public virtual void OnSwitchOff(){
	}
	public virtual void OnSwitchOn(){
	}

}
