using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour {

    public static EnemyBuilder instance;

	public LayerMask layer;

    public enum EnemyType
    {
        Normal,
        Fast,
        Strong,
        count
    };

	void Awake () {
        instance = this;
	}
	
    public GameObject Build(EnemyType type)
    {
        GameObject go = EnemyFactory.instance.Create(type);
		go.tag = "Enemy";
        Character enemyCharacter = go.GetComponent<Character>();

        go.AddComponent<Enemy>();

		go.layer = LayerMask.NameToLayer ("Enemy");


        switch (type)
        {
		case EnemyType.Normal:
			enemyCharacter.movement.speed = 7f;
            go.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Zombie1");
			enemyCharacter.SetHealth (40f);
                enemyCharacter.startHealth = 40f;
                break;
            case EnemyType.Fast:
			enemyCharacter.movement.speed = 13f;
            go.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("ZombieFast");
			enemyCharacter.SetHealth (20f);
                enemyCharacter.startHealth = 20f;
                break;
            case EnemyType.Strong:
			enemyCharacter.movement.speed = 5f;
            go.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("ZombieHeavy");
			enemyCharacter.SetHealth (100f);
                enemyCharacter.startHealth = 100f;
                break;
        }

        return go;
    }
}
