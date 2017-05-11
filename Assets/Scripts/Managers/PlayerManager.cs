using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    Character player;

	void Awake () {
        instance = this;
        player = ((GameObject)Instantiate(Resources.Load("Character"))).GetComponent<Character>();
		player.GetComponent<Rigidbody2D> ().mass = 10;
	}
	
	void Update () {
        player.movement.direction = InputManager.instance.GetMovementDirection();
		player.spriteController.pointToLook = player.movement.GetPosition() + InputManager.instance.GetAimDirection();
        /*if (player.movement.direction.magnitude > 0)
        {
        }*/
    }

    public Character GetPlayer() {
        return player;
    }
}
