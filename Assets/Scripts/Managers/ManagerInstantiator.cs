using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInstantiator : MonoBehaviour {

    public GameObject[] managers;

	void Awake () {
		foreach(GameObject m in managers)
        {
            Instantiate(m).transform.SetParent(transform);
        }
	}
}
