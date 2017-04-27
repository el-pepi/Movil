﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public CharacterMovement movement;
	public float lifeTime = 3f;

	float actualLifetime;

	void Start () {
		movement = GetComponent<CharacterMovement> ();
	}
	
	void Update () {
		actualLifetime -= Time.deltaTime;
		if (actualLifetime <= 0) {
			TurnOff();
		}
	}

	public void Reset(){
		actualLifetime = lifeTime;
		gameObject.SetActive (true);
	}

	void TurnOff(){
		gameObject.SetActive (false);
	}
}
