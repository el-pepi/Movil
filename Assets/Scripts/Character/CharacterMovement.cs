using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public Vector2 direction;
	public float speed = 5;

	Rigidbody2D rBody;

	Character character;

	void Awake () {
		rBody = GetComponent<Rigidbody2D> ();
		character = GetComponent<Character> ();
	}

	void FixedUpdate(){
		rBody.velocity = direction.normalized * speed;
		character.spriteController.pointToLook = (Vector2)transform.position + direction;
	}

	public Vector2 GetPosition(){
		return rBody.position;
	}
}
