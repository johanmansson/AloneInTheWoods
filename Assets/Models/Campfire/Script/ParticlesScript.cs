using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour {
	public static int maxParticles;
	public ParticleSystem part;
	public AudioSource source;
	float timeIntensity = 1.0f;
	int particleIntensity =1;

    bool wolfSoundPlayed = false;

	public int lifeTime=60;

    public GameObject light;
    
	// Use this for initialization
	void Start () {
        part = GetComponent<ParticleSystem>();
		var main = part.main;
		main.duration += lifeTime;
        main.maxParticles += lifeTime;
	
		InvokeRepeating("DecreaseParticles", 0.0f, timeIntensity);
	}


    void DecreaseParticles()
    {
        part.maxParticles -= particleIntensity;

        if(part.maxParticles == 0)
        {
            CancelInvoke();
            part.Stop();
            light.SetActive(false);
        }
    }


    


    public void AddMoreParticles(int seconds) {
        var main = part.main;
        main.duration += seconds;
        part.maxParticles += seconds;
        wolfSoundPlayed = false;
        GameObject.Find("Explosion").GetComponent<ExplosionScript>().Explode();
    }

	// Update is called once per frame
	void Update () {
		
        

        if(part.maxParticles <= 10)
        {
            //AddMoreParticles(20);
            if(!wolfSoundPlayed)
            {
                if(source)
                {
                    source.Play();
                }
                wolfSoundPlayed = true;

            }
        }

        


	}

   

}
