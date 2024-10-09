// First Person view for Armstrong digital twin

// Change position of OVRCameraRig to match that of ZED mini while Armstrong moves. I used OVRCameraRig instead of OVRPlayerController
// because we don't want the the player to be the camera, we still want armstrong to be the player. 
// Note: for stationary 3rd person camera uncheck FirstPersonCamera box in OVRCameraRig inspector
// Katy McCutchan
// May 16 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private OVRCameraRig overCameraRig; //initiallize camera
    public GameObject Armstrong; //initialize armstrong
    public Vector3 offset = new Vector3(-0.05f,0.3f,0.1462f); //height offset for Armstrong's eyes in global frame
 

    // Start is called before the first frame update
    void Start()
    {
        overCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>(); // find postion of OVR Camera Rig
        Armstrong = GameObject.Find("ZEDM"); //gets ZED mini
    
    }


    // Update is called once per frame (use LateUpdate to change camera position after armstrong has moved)
    void LateUpdate()
    {
        Vector3 armstrongPos = Armstrong.transform.position; //get armstrong's eye position, including offset of zed mini
        Vector3 localPos = Armstrong.transform.localPosition + offset; //local position of camera (in armstrong frame)
        Vector3 globalZEDPos = transform.TransformVector(localPos); //camera location in global coordinates
        Quaternion armstrongRotQuat = Armstrong.transform.rotation; //rotation of armstrong in world space in quaternions
        Quaternion viewAdjustement = Quaternion.AngleAxis(-90, Vector3.left);// adjustment for difference between armstrong frame and global frame
        Quaternion oculusAdjustment = Quaternion.AngleAxis(35, Vector3.right); //adjustment for rotation of oculus to be more comfortable to look down 
        overCameraRig.transform.position = armstrongPos + globalZEDPos; //position of camera 
        overCameraRig.transform.rotation = armstrongRotQuat*viewAdjustement*oculusAdjustment; //set camera rotation to armstrong's rotation (multiply quaternions to incorporate all three rotations)
    }
}
