using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour {
	public static int maxParticles;
	public ParticleSystem part;
	public AudioSource source;
	float timeIntensity = 0f;
	int particleIntensity =2;
	bool under10=false;

	public int lifeTime=60;



	// Use this for initialization
	void Start () {
		int firstMethodTime = lifeTime - (32+2);
		timeIntensity = firstMethodTime / 15;
	
	

		maxParticles = 40;
		part = GetComponent<ParticleSystem>();
		var main = part.main;
		main.duration = lifeTime;
	
		InvokeRepeating("ChangeParticlesIntensity", 2.0f, timeIntensity);
	}

	void ChangeParticlesIntensity(){
		part.maxParticles -= particleIntensity;
	
	}
	void SecondChangeParticlesIntensity(){
		part.maxParticles -= particleIntensity;
	}

    public void AddMoreParticles() {
        part.maxParticles += 20;
        print("More particles added!");
    }

	// Update is called once per frame
	void Update () {
		if (part.maxParticles == 0) {
			CancelInvoke ();
			part.Stop ();
		}
		if (part.maxParticles <= 10) {
			if (!under10) {
				if(source)
					source.Play ();
				CancelInvoke ();
				timeIntensity = 3.0f;
				particleIntensity = 1;
				under10 = true;
				InvokeRepeating("SecondChangeParticlesIntensity", 2.0f, timeIntensity);
			}
		}
	}

}
