using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSteelSparks : MonoBehaviour
{

    bool sparks = false;
    public AudioSource audio;



    void ChangeSparksToFalse()
    {
        sparks = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Knife")
        {
            print("Sparks!!!!!");
            GameObject.Find("RightHandExplosion").GetComponent<ExplosionScript>().Explode();
            GameObject.Find("Fire steel").GetComponent<AudioSource>().Play();
            sparks = true;
            Invoke("ChangeSparksToFalse", 0.5f);
        }

        if (other.gameObject.name == "Trigger2" && sparks)
        {
            print("Start Fire!");
            GameObject.Find("Flame Particles").GetComponent<ParticlesScript>().startFire();
            GameObject.Find("Flame Particles2").GetComponent<ParticlesScript>().startFire();
            GameObject.Find("Heat Particles").GetComponent<ParticlesScript>().startFire();
            GameObject.Find("Spark Particles").GetComponent<ParticlesScript>().startFire();
            GameObject.Find("Campfire").GetComponent<FireLightScript>().Explode();
        }



    }
}
