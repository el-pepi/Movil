using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour {

    public static InputManager instance;

    public UnityEvent fireDownEvent;
    public UnityEvent fireUpEvent;
    public UnityEvent weaponSwitchEvent;

    IInput customInput;

    void Awake()
    {
        instance = this;

#if UNITY_STANDALONE
        customInput = new InputStandalone();
#endif
    }

    void Update()
    {
        if (customInput.GetFireDown())
        {
            fireDownEvent.Invoke();
        }
        if (customInput.GetFireUp())
        {
            fireUpEvent.Invoke();
        }
        if (customInput.ChangeWeapon())
        {
            weaponSwitchEvent.Invoke();
        }
    }

    public Vector2 GetMovementDirection()
    {
        return customInput.GetMovementDirection();
    }
}
