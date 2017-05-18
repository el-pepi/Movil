using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    Character player;

	void Awake () {
        instance = this;
        player = ((GameObject)Instantiate(Resources.Load("Character"))).GetComponent<Character>();
		player.GetComponent<Rigidbody2D> ().mass = 10;
        player.gameObject.SetActive(false);
        player.gameObject.layer = LayerMask.NameToLayer("Player");
        player.tag = "Player";
    }

    void Start()
    {
        player.deathEvent.AddListener(OnPlayerDeath);
        GameManager.instance.StateChangeEvent.AddListener(OnGameStateChange);
        Instantiate<GameObject>(Resources.Load<GameObject>("MuzzleFlash"), player.transform.GetChild(0));
    }
	
	void Update () {
        player.movement.direction = InputManager.instance.GetMovementDirection();
		player.spriteController.pointToLook = player.movement.GetPosition() + InputManager.instance.GetAimDirection();
    }

    public Character GetPlayer() {
        return player;
    }

    void OnGameStateChange()
    {
        player.gameObject.SetActive(GameManager.instance.state==GameState.Game);
        if(GameManager.instance.state == GameState.Game)
        {
            player.SetHealth(100f);
            player.transform.position = Vector2.zero;
        }
    }

    void OnPlayerDeath()
    {
        GameManager.instance.GameOver();
    }
}
