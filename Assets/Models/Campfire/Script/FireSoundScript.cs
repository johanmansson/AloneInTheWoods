using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoundScript : MonoBehaviour {
	public AudioSource source;
	// Use this for initialization
	float lifeTime=60f;
	float intensity= 0f;

	void Start () {
		source = GetComponent<AudioSource> ();
		intensity = 1.0f / lifeTime;
		InvokeRepeating("LowerFireSound", 2.0f, 1);
	}

	void LowerFireSound(){
		source.volume -=intensity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
