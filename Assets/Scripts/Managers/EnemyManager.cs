using UnityEngine;

public class EnemyManager : MonoBehaviour {

    float spawnTimer = 3f;

    void Start()
    {
        GameManager.instance.StateChangeEvent.AddListener(OnGameStateChange);
        enabled = false;
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
        GameObject go = EnemyBuilder.instance.Build((EnemyBuilder.EnemyType)Random.Range(0,2));
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
        }
    }
}
