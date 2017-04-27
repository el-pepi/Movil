using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public Vector2 direction;
	public float speed = 5;

	Rigidbody2D rBody;

	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		rBody.velocity = direction * speed;
	}

	public Vector2 GetPosition(){
		return rBody.position;
	}
}
