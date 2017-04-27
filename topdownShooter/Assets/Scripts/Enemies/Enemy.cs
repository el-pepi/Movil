using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Transform playerTrans;
    Character character;

	void Awake () {
        character = GetComponent<Character>();
        playerTrans = PlayerManager.instance.GetPlayer().transform;
	}
	
	void Update () {
        character.movement.direction = (playerTrans.position - transform.position).normalized;
	}
}
