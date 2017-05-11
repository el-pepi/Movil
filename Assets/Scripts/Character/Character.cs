using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour {

	public CharacterMovement movement;
	public SpriteControler spriteController;

	float health = 100;

    public UnityEvent deathEvent;
    public UnityEvent hpUpdateEvent;

    void Awake () {
		movement = GetComponent<CharacterMovement> ();
		spriteController = GetComponent<SpriteControler> ();
        deathEvent = new UnityEvent();
        hpUpdateEvent = new UnityEvent();
    }

	public void SetHealth(float value){
		health = value;
        hpUpdateEvent.Invoke();
    }

	public void TakeDamage(float value){
        if (health <= 0)
        {
            return;
        }
        SetHealth(health -= value);
		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
        deathEvent.Invoke();
		gameObject.SetActive (false);
	}

    public float GetHealth()
    {
        return health;
    }
}
