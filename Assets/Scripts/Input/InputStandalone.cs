using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStandalone : IInput
{
    public bool ChangeWeapon()
    {
        return Input.GetKeyDown(KeyCode.Tab);
    }

    public bool GetFireDown()
    {
        return Input.GetButtonDown("Fire1");
    }

    public bool GetFireUp()
    {
        return Input.GetButtonUp("Fire1");
    }

	public Vector2 GetMovementDirection()
	{
		return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
	public Vector2 GetAimDirection()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		//PlayerManager.instance.GetPlayer ().transform.position;
		//return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		mousePos -= PlayerManager.instance.GetPlayer ().transform.position;
		return mousePos.normalized;
	}
}
