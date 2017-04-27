using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    Character player;

	void Awake () {
        instance = this;
        player = ((GameObject)Instantiate(Resources.Load("Character"))).GetComponent<Character>();
	}
	
	void Update () {
        player.movement.direction = InputManager.instance.GetMovementDirection();
        if (player.movement.direction.magnitude > 0)
        {
            player.spriteController.pointToLook = player.movement.GetPosition() + player.movement.direction;
        }
    }

    public Character GetPlayer() {
        return player;
    }
}
