using UnityEngine;

public class GameoverScreen : MonoBehaviour {

    void Start()
    {
        GameManager.instance.StateChangeEvent.AddListener(GameStateChanged);
        gameObject.SetActive(false);
    }

    public void OnStartClick()
    {
        GameManager.instance.StartGame();
    }

    void GameStateChanged()
    {
        gameObject.SetActive(GameManager.instance.state == GameState.GameOver);
    }

    public void OnResetClick()
    {
        GameManager.instance.Reset();
    }
}
