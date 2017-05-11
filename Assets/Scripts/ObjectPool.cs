using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	public GameObject obj;
	public int startSize;

	List<GameObject> availableObjects;

	void Start () {
		availableObjects = new List<GameObject> ();

		int i = startSize;
		while (i > 0) {
			AddObjectToPool ();
		}
	}

	public GameObject getPooledObject(){
		foreach (GameObject g in availableObjects) {
			if (g.activeSelf == false) {
				g.SetActive (true);
				return g;
			}
		}
		AddObjectToPool ();
		return GetFromAvailablePool ();
	}

	GameObject GetFromAvailablePool(){
		GameObject go = availableObjects [0];
		//availableObjects.RemoveAt (0);
		return go;
	}

	void AddObjectToPool(){
		GameObject go = Instantiate (obj)as GameObject;
		availableObjects.Add (go);
	}
}
