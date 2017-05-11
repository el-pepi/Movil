using UnityEngine;

public class StartScreen : MonoBehaviour {

    void Start()
    {
        GameManager.instance.StateChangeEvent.AddListener(GameStateChanged);
    }

    public void OnStartClick()
    {
        GameManager.instance.StartGame();
    }

    void GameStateChanged()
    {
        gameObject.SetActive(GameManager.instance.state == GameState.Start);
    }
}
