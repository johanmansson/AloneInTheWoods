
using UnityEngine;
using Valve.VR;

public class FireSteelSparks : MonoBehaviour
{

    bool sparks = false;
    public AudioSource audio;

    
    //private SteamVR_TrackedObject trackedObj;
   // private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private void Start()
    {
        //trackedObj = GetComponent<SteamVR_TrackedObject>();

        //OpenVR.System.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.RightHand);
        //OpenVR.System.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.LeftHand);
    }



    void ChangeSparksToFalse()
    {
        sparks = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Knife")
        {
            SteamVR_Controller.Input(1).TriggerHapticPulse((ushort)3999);
            SteamVR_Controller.Input(2).TriggerHapticPulse((ushort)3999);

           // controller.TriggerHapticPulse((ushort)Mathf.Lerp(1, 3999, 1));

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
            GameObject.Find("Campfire").GetComponent<FireLightScript>().startLight();
        }



    }
}
