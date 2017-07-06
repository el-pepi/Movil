using UnityEngine;
using UnityEngine.Events;

public enum hpUpdateType
{
    reset,
    heal,
    damage
}

public class HpUpdateEvent : UnityEvent<hpUpdateType> { }

public class Character : MonoBehaviour {



	public CharacterMovement movement;
	public SpriteControler spriteController;

	float health = 100;
    public float startHealth = 100;

    public UnityEvent deathEvent;
    public HpUpdateEvent hpUpdateEvent;

    void Awake () {
		movement = GetComponent<CharacterMovement> ();
		spriteController = GetComponent<SpriteControler> ();
        deathEvent = new UnityEvent();
        hpUpdateEvent = new HpUpdateEvent();
    }

	public void SetHealth(float value , hpUpdateType type = hpUpdateType.reset)
    {
		health = value;
        hpUpdateEvent.Invoke(type);
    }

	public void TakeDamage(float value){
        if (health <= 0)
        {
            return;
        }
        SetHealth(health -= value , hpUpdateType.damage);
		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
        ParticleManager.instance.Emit("BloodExplosion",transform.position,1);
        deathEvent.Invoke();
		gameObject.SetActive (false);
	}

    public float GetHealth()
    {
        return health;
    }

    public void Reset()
    {
        health = startHealth;
    }
}
