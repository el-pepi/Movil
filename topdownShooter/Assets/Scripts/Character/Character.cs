using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public CharacterMovement movement;
	public SpriteControler spriteController;

	float health = 100;

	void Awake () {
		movement = GetComponent<CharacterMovement> ();
		spriteController = GetComponent<SpriteControler> ();
	}

	public void SetHealth(float value){
		health = value;
	}

	public void TakeDamage(float value){
		health -= value;
		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
		print ("ded");
		gameObject.SetActive (false);
	}
}
