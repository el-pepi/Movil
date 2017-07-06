using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
    public float hp = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerManager.instance.GetPlayer().SetHealth(PlayerManager.instance.GetPlayer().GetHealth()+hp , hpUpdateType.heal);
            gameObject.SetActive(false);
        }
    }
}
