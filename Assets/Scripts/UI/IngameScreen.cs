using UnityEngine;
using UnityEngine.UI;

public class IngameScreen : MonoBehaviour {

    public Text healthLabel;
    public Image weaponTimer;

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

    void UpdatePlayerHealth()
    {
        healthLabel.text = ((int)PlayerManager.instance.GetPlayer().GetHealth()).ToString("");
    }
}
