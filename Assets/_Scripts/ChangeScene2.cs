using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ChangeScene2 : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    

    public GameObject fader;



    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        OpenVR.System.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.RightHand);
        //OpenVR.System.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.LeftHand);

        

    }


    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (controller.GetPressDown(triggerButton))
        {
            Debug.Log("Trigger Down");

        }

        if (controller.GetPressUp(triggerButton))
        {
            Debug.Log("Trigger up");

        }


        if (controller.GetPressDown(gripButton))
        {
            print("gripped!");
        }

        if (controller.GetPressUp(gripButton))
        {
            print("ungripped!");
            //StartCoroutine(sceneChange());
            GameObject.Find("Controller (left)").GetComponent<ChangeScene>().startSceneChange();
        }

    }

    
}
