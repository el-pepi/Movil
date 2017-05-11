using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathStuff : MonoBehaviour {

	public static float GetRotationToLook(Vector2 position, Vector2 point){
		Vector2 trnsPos = position;
		Vector2 diff = point - trnsPos;
		diff.Normalize ();
		return Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg + 90;
	}
}