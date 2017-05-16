using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;



public class ChangeScene : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private AsyncOperation scene;



    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        OpenVR.System.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.RightHand);
        OpenVR.System.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.LeftHand);

        scene = SceneManager.LoadSceneAsync("First", LoadSceneMode.Single);
        scene.allowSceneActivation = false;

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


        if(controller.GetPressDown(gripButton))
        {
            print("gripped!");
        }

        if(controller.GetPressUp(gripButton))
        {
            print("ungripped!");
            scene.allowSceneActivation = true;
        }

    }






}
