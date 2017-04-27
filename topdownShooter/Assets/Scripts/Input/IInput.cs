using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput {

    Vector2 GetMovementDirection();

    bool GetFireDown();
    bool GetFireUp();
    bool ChangeWeapon();
}
