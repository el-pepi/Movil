using UnityEngine;

public class MuzzleFlash : MonoBehaviour {

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	void Start () {
        WeaponManager.instance.fireEvent.AddListener(OnWeaponFire);
	}
	
    void OnWeaponFire()
    {
        anim.SetTrigger("Fire");
        ParticleManager.instance.Emit("BulletShell",transform.position+transform.right*-0.5f,transform.rotation.eulerAngles.z + 240f,1);
    }

}
