using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Start,
    Game,
    GameOver
}

public class GameManager : MonoBehaviour {

	public static GameManager instance;

    public UnityEvent StateChangeEvent;

    public GameState state;

	void Awake () {
		instance = this;
        StateChangeEvent = new UnityEvent();
	}

    void Start()
    {
        ChangeState(GameState.Start);
    }

    public void ChangeState(GameState newState)
    {
        state = newState;
        switch (state)
        {
            case GameState.Start:

                break;
            case GameState.Game:

                break;
        }
        StateChangeEvent.Invoke();
    }

    public void StartGame()
    {
        ChangeState(GameState.Game);
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }

    public void Reset()
    {
        ChangeState(GameState.Start);
    }
}
