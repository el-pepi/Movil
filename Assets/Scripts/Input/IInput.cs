using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput {

    Vector2 GetMovementDirection();
	Vector2 GetAimDirection();

    bool GetFireDown();
    bool GetFireUp();
    bool ChangeWeapon();
}
