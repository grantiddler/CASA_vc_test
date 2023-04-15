using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//ROS specific libraries
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Std; //Header message

public class LatencyAnalysis : MonoBehaviour
{
    private ROSConnection ros;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        ROSConnection.instance.Subscribe<HeaderMsg>("/analysis/header", HeaderMessage);

    }

    
    void HeaderMessage(HeaderMsg header) {
        // Debug.Log("Time in ns:" + header.stamp);
        if (count == 5) ROSConnection.instance.Publish("/analysis/header_reponse", header);
        count++;
        

    }

}
