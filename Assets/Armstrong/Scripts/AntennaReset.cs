// AntennaReset resets antenna to original positon and orientation when the R key is pressed. Can be used if the antenna gets knocked over.  
//Note : Only Works in game mode, not scene mode. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaReset : MonoBehaviour
{

    public GameObject antenna; // declare antenna game object
    public Vector3 defaultPos; 
    public Quaternion defaultRot;

    // Start is called before the first frame update
    void Start()
    {
        antenna  = GameObject.Find("block_antenna"); //get antenna game object
        defaultPos = antenna.transform.position; //get default/original antenna position
        defaultRot = antenna.transform.rotation; //get default/original position

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //returns true when R is pressed an released
            {
                antenna.transform.position = defaultPos; //resets antenna position
                antenna.transform.rotation = defaultRot; // resets antenna rotation
                Debug.Log("Antenna Reset");   
            }    
    }
}
