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
    bool fireStarted = false;
	public int lifeTime=60;
    public int duration = 300;

    public GameObject light;
    

    
	// Use this for initialization
	void Start () {
        part = GetComponent<ParticleSystem>();
		var main = part.main;
		main.duration += duration;
        light.SetActive(false);
        
	}
    
    
    
    public void startFire()
    {
        if (!fireStarted)
        {
            GameObject.Find("Flame Particles").GetComponent<AudioSource>().Play();
            part.maxParticles += 60;
/*
            GameObject.Find("Heat Particles").GetComponent<ParticleSystem>().maxParticles += 60;

            GameObject.Find("Flame Particles").GetComponent<ParticleSystem>().maxParticles += 60;


            GameObject.Find("Flame Particles2").GetComponent<ParticleSystem>().maxParticles += 60;

            GameObject.Find("Spark Particles").GetComponent<ParticleSystem>().maxParticles += 60;

            GameObject.Find("Heat Particles").GetComponent<ParticleSystem>().maxParticles += 60;
            */
            light.SetActive(true);



          
            GameObject.Find("Explosion").GetComponent<ExplosionScript>().Explode();

            InvokeRepeating("DecreaseParticles", 0.0f, timeIntensity);

            fireStarted = true;
        }

     
    }
    


    void DecreaseParticles()
    {
        print(part.name + ": " + part.maxParticles);
        part.maxParticles -= particleIntensity;

        if(part.maxParticles == 0)
        {
            CancelInvoke();
            part.Stop();
            light.SetActive(false);
        }
    }

    void Explode()
    {

        if(part.maxParticles > 0) { 
        GameObject.Find("Explosion").GetComponent<ExplosionScript>().Explode();
            if (part.maxParticles <= 50)
            {
                GameObject.Find("Heat Particles").GetComponent<ParticleSystem>().maxParticles += 20;

                GameObject.Find("Flame Particles").GetComponent<ParticleSystem>().maxParticles += 20;


                GameObject.Find("Flame Particles2").GetComponent<ParticleSystem>().maxParticles += 20;

                GameObject.Find("Spark Particles").GetComponent<ParticleSystem>().maxParticles += 20;

                GameObject.Find("Heat Particles").GetComponent<ParticleSystem>().maxParticles += 20;



                GameObject.Find("Campfire").GetComponent<FireLightScript>().Explode();
            }
        }
       
    }

    


    public void AddMoreParticles(int seconds) {
        var main = part.main;
        //main.duration += 20;
        Invoke("Explode", 0.0f);
        wolfSoundPlayed = false;
        
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
