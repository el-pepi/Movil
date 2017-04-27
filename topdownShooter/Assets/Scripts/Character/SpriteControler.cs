using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControler : MonoBehaviour {

	public Transform spriteTransfom;
	public float rotationSpeed;

	Quaternion targetRotation = Quaternion.identity;
	Quaternion actualRotation = Quaternion.identity;
	
	public Vector2 pointToLook;

	void Update () {
		targetRotation = Quaternion.Euler (0, 0, GetRotationToLook (pointToLook));
		actualRotation = Quaternion.Lerp (actualRotation, targetRotation, rotationSpeed * Time.deltaTime);

		spriteTransfom.rotation = actualRotation;
	}

	float GetRotationToLook(Vector2 point){
		Vector2 trnsPos = spriteTransfom.position;
		Vector2 diff = point - trnsPos;
		diff.Normalize ();
		return Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg + 90;
	}
}
