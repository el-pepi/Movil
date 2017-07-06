using UnityEngine;

public class WeaponPicup : MonoBehaviour {

    public int weaponNumber = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            WeaponManager.instance.SwitchToWeapon(weaponNumber);
            gameObject.SetActive(false);
        }
    }
}
