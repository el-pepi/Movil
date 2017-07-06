using UnityEngine;
using UnityEngine.UI;

public class IngameScreen : MonoBehaviour {

    public Text healthLabel;
    public Image weaponTimer;
	public Animator glowAnim;

	void Start () {
        GameManager.instance.StateChangeEvent.AddListener(GameStateChanged);
        PlayerManager.instance.GetPlayer().hpUpdateEvent.AddListener(UpdatePlayerHealth);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        weaponTimer.fillAmount = WeaponManager.instance.weaponTimer / 15f;
    }

    void GameStateChanged()
    {
        gameObject.SetActive(GameManager.instance.state == GameState.Game);
    }

    void UpdatePlayerHealth(hpUpdateType type)
    {
        healthLabel.text = ((int)PlayerManager.instance.GetPlayer().GetHealth()).ToString("");
        if (type == hpUpdateType.damage)
        {
        }
        switch (type)
        {
            case hpUpdateType.damage:
                glowAnim.SetTrigger("Hit");
            break;
            case hpUpdateType.heal:
                glowAnim.SetTrigger("Heal");
            break;
        }
    }
}
