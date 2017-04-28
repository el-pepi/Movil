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
		targetRotation = Quaternion.Euler (0, 0, 270+MathStuff.GetRotationToLook(spriteTransfom.position,pointToLook));
		actualRotation = Quaternion.Lerp (actualRotation, targetRotation, rotationSpeed * Time.deltaTime);

		spriteTransfom.rotation = actualRotation;
	}
}
