using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    float spawnTimer = 3f;

	void Update () {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = 2f;
            SpawnEnemy();
        }
	}

    void SpawnEnemy()
    {
        GameObject go = EnemyBuilder.instance.Build((EnemyBuilder.EnemyType)Random.Range(0,2));
		go.transform.position = (Vector2)PlayerManager.instance.GetPlayer().transform.position + Random.insideUnitCircle.normalized * 30f;
    }
}
