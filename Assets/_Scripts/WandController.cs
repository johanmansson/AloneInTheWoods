using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    /**
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;
    **/

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    /**
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;
    **/
   


   


    HashSet<InteracibleItem> objectsHoveringOver = new HashSet<InteracibleItem>();
    private InteracibleItem interactibleItem;
    private InteracibleItem closestItem;
    // Use this for initialization


    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }


    private void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update() {

        if (Controller.GetAxis() != Vector2.zero) {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        
        if (Controller.GetHairTriggerDown()) {
            Debug.Log(gameObject.name + " Trigger Press");
        }

       
        if (Controller.GetHairTriggerUp()) {
            Debug.Log(gameObject.name + " Trigger Release");
        }

       
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
            Debug.Log(gameObject.name + " Grip Press");
        }

     
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
            Debug.Log(gameObject.name + " Grip Release");
        }

    }
    }
