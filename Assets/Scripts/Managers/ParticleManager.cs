using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

    public static ParticleManager instance;

    Dictionary<string, ParticleSystem> particles;

	void Awake () {
        instance = this;

        particles = new Dictionary<string, ParticleSystem>();

        foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            particles.Add(p.name,p);
        }
	}

    public void Emit(string name, Vector3 position, int ammount)
    {
        particles[name].transform.position = position;
        particles[name].Emit(ammount);
    }

    public void Emit(string name, Vector3 position,float rotation, int ammount)
    {
        particles[name].transform.rotation = Quaternion.Euler(0,0,rotation);
        Emit(name,position,ammount);
    }
}
