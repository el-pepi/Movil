using UnityEngine;

public class Enemy : MonoBehaviour {

    Transform playerTrans;
    Character character;

    public float delayBetweenAttacks = 1f;
    public float attackDamage = 10f;

    float attackDelay = 0;

	void Awake () {
        character = GetComponent<Character>();
        playerTrans = PlayerManager.instance.GetPlayer().transform;

        character.deathEvent.AddListener(OnDeath);
	}
	
	void Update () {
        character.movement.direction = (playerTrans.position - transform.position).normalized;
        if (attackDelay > 0)
        {
            attackDelay -= Time.deltaTime;
        }
        if ((playerTrans.position - transform.position).magnitude < 2f)
        {
            Attack();
        }
	}

    void Attack()
    {
        if (attackDelay <= 0)
        {
            PlayerManager.instance.GetPlayer().TakeDamage(attackDamage);
            attackDelay = delayBetweenAttacks;
        }
    }

    void OnDeath()
    {
        WeaponManager.instance.WeaponDrop(transform.position);
    }
}
