using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

    public static EnemyFactory instance;

    public GameObject characterPrefab;

	void Start () {
        instance = this;
	}
	
    public GameObject Create(EnemyBuilder.EnemyType type)
    {
        return Instantiate(characterPrefab);
    }

}
