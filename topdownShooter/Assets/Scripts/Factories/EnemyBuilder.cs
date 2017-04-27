using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour {

    public static EnemyBuilder instance;

    public enum EnemyType
    {
        Normal,
        Fast,
        Strong
    };

	void Awake () {
        instance = this;
	}
	
    public GameObject Build(EnemyType type)
    {
        GameObject go = EnemyFactory.instance.Create(type);
        Character enemyCharacter = go.GetComponent<Character>();

        go.AddComponent<Enemy>();

        switch (type)
        {
            case EnemyType.Normal:
                enemyCharacter.movement.speed = 7f;
                break;
            case EnemyType.Fast:
                enemyCharacter.movement.speed = 15f;
                break;
            case EnemyType.Strong:
                enemyCharacter.movement.speed = 5f;
                break;
        }

        return go;
    }
}
