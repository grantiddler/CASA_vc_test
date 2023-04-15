using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveManager : MonoBehaviour
{
    //OVR CameraRig
    public GameObject Player;
    public GameObject TrackingSpace;
    //Legstrong Frame
    public GameObject Legstrong;

    //Height offset when in FPV
    public Vector3 offset = new Vector3(0,1.3f,0);
   
    //Saved variables
    private Vector3 TPVTransform;
    private Vector3 TPVRotation;

    //States
    public string state;
    private string prevstate;

    void Start()
    {   //Get our initial pose and set our default state to third person
        TPVTransform = Player.transform.position;
        TPVRotation = Player.transform.eulerAngles;
        state = "fpv";
    }

    //First person view
    void fpv()
    {
        if (prevstate == "tpv") TrackingSpace.transform.eulerAngles = new Vector3(TrackingSpace.transform.eulerAngles.x, TrackingSpace.transform.eulerAngles.y+90, TrackingSpace.transform.eulerAngles.z);
        //Teleport to legstrong
        TrackingSpace.transform.eulerAngles = new Vector3(Legstrong.transform.eulerAngles.x, Legstrong.transform.eulerAngles.y+90, Legstrong.transform.eulerAngles.z);
        Player.transform.position = Legstrong.transform.position+offset;
        prevstate = "fpv";
    }

    //Third person view
    void tpv()
    {
        //Reset to the last TPV position
        if (prevstate == "fpv")
        {
            TrackingSpace.transform.eulerAngles = new Vector3(TrackingSpace.transform.eulerAngles.x, TrackingSpace.transform.eulerAngles.y - 90, TrackingSpace.transform.eulerAngles.z);
            Player.transform.position = TPVTransform;
            TPVRotation = Player.transform.eulerAngles;

        }
        //Continuously update tpv
        TPVTransform = Player.transform.position;
        TPVRotation = Player.transform.eulerAngles;

        prevstate = "tpv";
    }

    void Update()
    {
        //TO DO: Change these state changers accordingly.
        if (Input.GetKey("up")) state = "fpv";
        else if (Input.GetKey("down")) state = "tpv";

        if (state == "fpv") fpv();
        else if (state == "tpv") tpv();
    }

}
