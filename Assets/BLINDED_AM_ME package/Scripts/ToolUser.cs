using UnityEngine;
using System.Collections;

public class ToolUser : MonoBehaviour
{
    private bool collided = false;

    public Material capMaterial;

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        collided = true;


    }






    void Update()
    {

        if (collided)
        {
            RaycastHit hit;
            print("testar");



            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {

                GameObject victim = hit.collider.gameObject;
                print("testar2");

                if (victim.CompareTag("cut"))
                {
                    SteamVR_Controller.Input(2).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, 1));

                    GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                    if (!pieces[1].GetComponent<Rigidbody>())
                    {
                       // pieces[1].transform.localScale = new Vector3(10, 10, 10);
                        pieces[1].AddComponent<Rigidbody>();
                        pieces[1].AddComponent<BoxCollider>();
                        
                        pieces[1].tag = "cutable";

                    }
                    collided = false;



                    //Destroy (pieces [1], 1);
                }
                else if (victim.CompareTag("cutable"))
                {
                    victim.tag = "cut";
                    collided = false;
                    SteamVR_Controller.Input(2).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, 1));
                }
            }

        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
        Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
        Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

        Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.5f);

    }

}
