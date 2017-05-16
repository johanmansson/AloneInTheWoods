using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnFireTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "fuel")
        {
            print("Trigger on Fire!");
            Destroy(other.gameObject);
            GameObject.Find("Flame Particles").GetComponent<ParticlesScript>().AddMoreParticles(20);
        }
        


       
        
    }
    


}
