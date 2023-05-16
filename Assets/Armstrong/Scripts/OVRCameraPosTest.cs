//Script to test OVRCameraRig and experiment with moving OVRCameraRig.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCameraPosTest : MonoBehaviour
{
    [SerializeField] private OVRCameraRig overCameraRig; //import state of camera
    public Vector3 offset = new Vector3(0,1.3f,0); //height offset for Armstrong's eyes

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraPos = GetCameraPos(); //get position of camera
        Vector3 amrstrongPos = GetEyePos(); // get armstrong's eye position
        Debug.Log("Camera Position: " + cameraPos); 
    }

    Vector3 GetCameraPos() {
        //gets camera position
        overCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>(); // find postion of OVR Camera Rig
        return overCameraRig.centerEyeAnchor.position; // return postion of OVR Camera Rig
    }

    Vector3 GetEyePos() {


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
