//Script to test OVRCameraRig and experiment with moving OVRCameraRig.
// Katy McCutchan
// May 16 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCameraPosTest : MonoBehaviour
{
    [SerializeField] private OVRCameraRig overCameraRig; //initiallize camera
    public GameObject Armstrong; //initialize armstrong
    public Vector3 offset = new Vector3(0,0.65f,0); //height offset for Armstrong's eyes
 

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraPos = GetCameraPos(); //get position of camera 
        Armstrong = GameObject.Find("ZEDM"); //gets ZED mini 
    }

    // Get camera position
    Vector3 GetCameraPos() {
        
        overCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>(); // find postion of OVR Camera Rig
        return overCameraRig.centerEyeAnchor.position; // return postion of OVR Camera Rig
    }



    // Update is called once per frame (use LateUpdate to change camera position after amstrong has moved)
    void Update()
    {
        Vector3 armstrongPos = Armstrong.transform.position + offset; //get armstrong's eye position, including offset of zed mini
        Vector3 armstrongRot = Amrstrong.tansform.rotation; //rotation of armstong in world space
        overCameraRig.transform.position = armstrongPos; //sets camera position to position of zed mini
        //overCameraRig.transform.rotation = armstrongRot; //set camera rotation to armstrong's rotation
    }
}
