using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public ParticleSystem part;
    public AudioSource source;
    // Use this for initialization
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        //InvokeRepeating("Explode", 2.0f, 2.0f);
    }

    public void Explode()
    {
        part.Play();
        if (source)
        {
            source.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
