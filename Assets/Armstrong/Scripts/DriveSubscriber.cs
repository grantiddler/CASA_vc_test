using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//ROS specific libraries
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Geometry; //Twist message

/*
    Subscribes to the twist topic in order to drive armstrong in Unity.
    Author: Phaedra Curlin
*/

public class DriveSubscriber : MonoBehaviour {
    // ROS Connector
    private ROSConnection ros;

    //armstrong robot parameters
    public GameObject armstrong;
    public float SagittalGain = 1f; //gain related to linear velocity
    public float TransverseGain = 1f; //gain related to angular velocity

    private int numRobotJoints = 2;    
    // Articulation Bodies
    private ArticulationBody[] jointArticulationBodies;

    Vector3 linearVelocity, angularVelocity, compareVelocity;
    Vector3 prevLinear, prevAngular;

    void Start(){
        // Get ROS connection static instance
        ROSConnection.instance.Subscribe<TwistMsg>("/armstrong_velocity_controller/cmd_vel", drive);

        // Get the joints from the model in Unity
        jointArticulationBodies = new ArticulationBody[numRobotJoints];
        string l_wheel = "base_link/frame/l_wheel";
        jointArticulationBodies[0] = armstrong.transform.Find(l_wheel).GetComponent<ArticulationBody>(); //declare left wheel
        string r_wheel = "base_link/frame/r_wheel";
        jointArticulationBodies[1] = armstrong.transform.Find(r_wheel).GetComponent<ArticulationBody>(); //declare right wheel

    }
    
    void FixedUpdate()
    {
        //Adjust the velocity of the wheels every frame by adding torque to wheels for linear and angular velocity of rover
        //Linear velocity is multiplied by a factor of 0.4 so that speed of virtual rover matches speed of physical rover
    
        jointArticulationBodies[0].AddRelativeTorque(linearVelocity * SagittalGain*0.32f + angularVelocity * TransverseGain*0.7f); 
        jointArticulationBodies[1].AddRelativeTorque(linearVelocity * SagittalGain*0.32f - angularVelocity * TransverseGain*0.7f);
    }
   

    void drive(TwistMsg twist) {
        //Need to do a vector transformation because the coordinate system of Unity is different
        linearVelocity = new Vector3(0,0,-(float)twist.linear.x); 
        angularVelocity = new Vector3(0, 0, (float)twist.angular.z);
    }

    
}
