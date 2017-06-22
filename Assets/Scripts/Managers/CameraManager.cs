using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	Transform cam;
	Transform player;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;
		pos = cam.position;

		player = PlayerManager.instance.GetPlayer ().transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		pos.x = player.position.x;
		pos.y = player.position.y;
		cam.transform.position = pos;
	}
}
