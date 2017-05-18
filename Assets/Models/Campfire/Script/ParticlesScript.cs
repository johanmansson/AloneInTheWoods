using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour {
	public static int maxParticles;
	public ParticleSystem part;
	public AudioSource source;
	float timeIntensity = 1.0f;
	int particleIntensity =1;

    bool fireStarted = false;
	public int lifeTime=60;
    public int duration = 1000;
    public AudioSource angryWolfSound;
    public AudioSource wolfPrasseling;
    public AudioSource backgroundWolfs;

    public GameObject light;
    public GameObject Zombie;

    



    // Use this for initialization
    void Start () {
        part = GetComponent<ParticleSystem>();
		var main = part.main;
		main.duration += duration;
        light.SetActive(false);
        GameObject.Find("Flame Particles").GetComponent<ParticlesScript>().StartWolfSound();
        StartCoroutine(fireIsNotStarted());

        //InvokeRepeating("ShowZombie", 60.0f, 60.0f);
        InvokeRepeating("BackgroundWolfs", 20.0f, 20.0f);
	}

    public bool FireIsStarted()
    {
        return fireStarted;
    }


    IEnumerator fireIsNotStarted()
    {
        yield return new WaitForSeconds(25);
        if(!fireStarted)
        {
            if (wolfPrasseling)
            {
                wolfPrasseling.Play();
            }
        }
        yield return new WaitForSeconds(5);
        if (!fireStarted)
        {
            if (angryWolfSound)
            {
                angryWolfSound.Play();
            }
        }
        yield return new WaitForSeconds(2);
        if (!fireStarted)
        {
            GameObject.Find("SceneController").GetComponent<ChangeBackScene>().FireWasKilled();
        }



    }

    void BackgroundWolfs()
    {
        if (backgroundWolfs)
        {
            backgroundWolfs.Play();
        }
    }

    void ShowZombie()
    {
        print("Zombie should show");
        if (Zombie)
        {
            Zombie.SetActive(true);

        }
       
        Invoke("HideZombie", 0.5f);
    }

    void HideZombie()
    {
        print("Zombie should hide");
        if (Zombie)
        {
            Zombie.SetActive(false);
        }
       
    }

    public void StartWolfSound()
    {
        InvokeRepeating("WolfSounds", 25.0f, 30.0f);
    }
    
    void WolfSounds()
    {
        if (backgroundWolfs)
        {
            backgroundWolfs.Play();
            print("Wolf sounds");
        }
        
    }
    
    
    public void startFire()
    {
        if (!fireStarted)
        {

            InvokeRepeating("GrowFlames", 0.0f, 0.2f);
           
            GameObject.Find("Flame Particles").GetComponent<AudioSource>().Play();
            //part.maxParticles += 60;
/*
            GameObject.Find("Heat Particles").GetComponent<ParticleSystem>().maxParticles += 60;

            GameObject.Find("Flame Particles").GetComponent<ParticleSystem>().maxParticles += 60;


            GameObject.Find("Flame Particles2").GetComponent<ParticleSystem>().maxParticles += 60;

            GameObject.Find("Spark Particles").GetComponent<ParticleSystem>().maxParticles += 60;

            GameObject.Find("Heat Particles").GetComponent<ParticleSystem>().maxParticles += 60;
            */
            light.SetActive(true);



          
            //GameObject.Find("Explosion").GetComponent<ExplosionScript>().Explode();

          

            fireStarted = true;
        }

     
    }

    void GrowFlames()
    {
        part.maxParticles += 1;
        if (part.maxParticles >= 60)
        {
            CancelInvoke();
            InvokeRepeating("DecreaseParticles", 0.0f, timeIntensity);
        }
    }



    void DecreaseParticles()
    {
       
        part.maxParticles -= particleIntensity;
        if (part.maxParticles == 20)
        {
            if (wolfPrasseling)
            {
                wolfPrasseling.Play();
            }
        }
        if (part.maxParticles == 6)
        {
            if (angryWolfSound)
            {
                angryWolfSound.Play();
            }
        }
        if (part.maxParticles == 1)
        {
            if (angryWolfSound)
            {
                angryWolfSound.Play();
            }
        }
        if (part.maxParticles == 0)
        {
            CancelInvoke();
            part.Stop();
            light.SetActive(false);

            GameObject.Find("SceneController").GetComponent<ChangeBackScene>().FireWasKilled();
            
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
        
        
    }

	// Update is called once per frame
	void Update () {
		

	}

   

}
