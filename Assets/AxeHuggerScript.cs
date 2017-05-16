using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHuggerScript : MonoBehaviour {

    public GameObject oldWood;
    public AudioSource source1, source2;
    public GameObject wood1, wood2, wood3, wood4;

    public Material newWoodMaterial;

    private int count = 0;

    // Use this for initialization
    void Start()
    {
        wood1.SetActive(false);
        wood2.SetActive(false);
        wood3.SetActive(false);
        wood4.SetActive(false);


    }

    void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.name == "Axe")
        {

            count++;
            GameObject.Find("AudioAxeHugger").GetComponent<AudioSource>().Play();

            if (count == 2)
            {
                //source1.Play();
                oldWood.GetComponent<MeshRenderer>().material = newWoodMaterial;
            }

            if (count == 3)
            {
                //source2.Play();
                oldWood.SetActive(false);
                wood1.SetActive(true);
                wood2.SetActive(true);
                wood3.SetActive(true);
                wood4.SetActive(true);
            }



        }
    }


    private float GetCollisionForce(Collider col)
    {
        if (col.gameObject.name == "Axe")
        {
            



        }

        return 0;
    }


}

