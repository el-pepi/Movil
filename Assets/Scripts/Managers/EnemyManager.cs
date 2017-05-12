using UnityEngine;

public class EnemyManager : MonoBehaviour {

    float spawnTimer = 3f;

    Pool[] enemyPools;

    void Start()
    {
        GameManager.instance.StateChangeEvent.AddListener(OnGameStateChange);
        enabled = false;

        enemyPools = new Pool[(int)EnemyBuilder.EnemyType.count];
        for (int i = 0; i < (int)EnemyBuilder.EnemyType.count; i++)
        {
            enemyPools[i] = new Pool();
        }
    }

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
        int ind = Random.Range(0, (int)EnemyBuilder.EnemyType.count);
        GameObject go = enemyPools[ind].GetFromPool();
        if (go == null)
        {
            go = EnemyBuilder.instance.Build((EnemyBuilder.EnemyType)ind);
            enemyPools[ind].AddToPool(go);
        }
        else
        {
            go.GetComponent<Character>().Reset();
            go.SetActive(true);
        }
		go.transform.position = (Vector2)PlayerManager.instance.GetPlayer().transform.position + Random.insideUnitCircle.normalized * 30f;
    }

    void OnGameStateChange()
    {
        enabled = GameManager.instance.state == GameState.Game;
        if (GameManager.instance.state == GameState.Game)
        {
            spawnTimer = 3;
        }
        if (GameManager.instance.state == GameState.GameOver)
        {
            spawnTimer = 3;
            foreach(Pool p in enemyPools)
            {
                p.ResetAll();
            }
        }
    }
}
