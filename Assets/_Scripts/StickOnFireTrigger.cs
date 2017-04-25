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
        print("Trigger on Fire!");
        GameObject.Find("Flame Particles").GetComponent<ParticlesScript>().AddMoreParticles();
    }
    void OnTriggerExit(Collider other) {
        print("trigger exit");
    }


}
