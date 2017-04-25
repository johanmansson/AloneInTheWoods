﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracibleItem : MonoBehaviour {

    public Rigidbody rigidBody;

    private Vector3 posDelta;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;
    private float rotationFactor = 400f;
    private float velocityFactor = 20000f;

    private bool currentlyInteracting;
    private WandController attachedWand;
    private Transform interactionPoint;



    // Use this for initialization
    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;

    private GameObject objectInHand;

    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    private void SetCollidingObject(Collider col) {

        if (collidingObject || !col.GetComponent<Rigidbody>()) {
            return;
        }

        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other) {
        SetCollidingObject(other);
    }


    public void OnTriggerStay(Collider other) {
        SetCollidingObject(other);
    }


    public void OnTriggerExit(Collider other) {
        if (!collidingObject) {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject() {

        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }


    private FixedJoint AddFixedJoint() {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject() {

        if (GetComponent<FixedJoint>()) {

            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        objectInHand = null;
    }


    // Update is called once per frame
    void Update() {
        // 1
        if (Controller.GetHairTriggerDown()) {
            if (collidingObject) {
                GrabObject();
            }
        }

        // 2
        if (Controller.GetHairTriggerUp()) {
            if (objectInHand) {
                ReleaseObject();
            }
        }
    }
}
