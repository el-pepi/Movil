using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	Transform cam;
	Animator camAnim;
	Transform player;
	Vector3 pos;
	public Vector2 mapSize;

	// Use this for initialization
	void Start () {
		cam = Camera.main.transform.parent;
		camAnim = cam.GetComponent<Animator> ();
		pos = cam.position;

		player = PlayerManager.instance.GetPlayer ().transform;

		PlayerManager.instance.GetPlayer ().hpUpdateEvent.AddListener (OnPlayerHit);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		pos.x = Mathf.Clamp(player.position.x,-mapSize.x,mapSize.x);
		pos.y = Mathf.Clamp(player.position.y,-mapSize.y,mapSize.y);
		cam.transform.position = pos;
	}

	void OnPlayerHit(){
		camAnim.SetTrigger ("shake" + Random.Range (1, 3));
	}
}
