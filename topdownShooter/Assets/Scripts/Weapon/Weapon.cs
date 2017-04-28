using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public string weaponName;

	public SpriteRenderer spriteRenderer;

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		OnSwitchOff ();
	}

	public virtual void OnFirePress(){
	}
	public virtual void OnFireRelease(){
	}
	public virtual void OnSwitchOff(){
		spriteRenderer.enabled = false;
	}
	public virtual void OnSwitchOn(){
		spriteRenderer.enabled = true;
	}

}
