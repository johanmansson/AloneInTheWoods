using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moreGravity : MonoBehaviour {

	public void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    }

}
