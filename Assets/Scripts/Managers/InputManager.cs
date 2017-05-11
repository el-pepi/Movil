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
#elif UNITI_ANDROID
        GameObject mobileInputUI = Instantiate(Resources.Load<GameObject>("MobileInput"));
        mobileInputUI.transform.SetParent(GameObject.Find("Canvas").transform,false);
        customInput = mobileInputUI.GetComponent<InputMobile>();
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

	public Vector2 GetAimDirection()
	{
		return customInput.GetAimDirection();
	}
}
