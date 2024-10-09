using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//ROS specific libraries
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Geometry;
using RosMessageTypes.Sensor; //Joint state message
/*
    Subscribes to the joint state topic in order to position armstrong's arm in Unity.
    Author: Phaedra Curlin
*/

public class ArmSubscriber : MonoBehaviour
{
    // ROS Connector
    private ROSConnection ros;

    //armstrong robot parameters
    public GameObject armstrong;
    //double before = 0.0;
    //double after = 0.0;
    private int numRobotJoints = 14; //Number of joints associated with the arm
    private int armStartNum = 6;
    private ArticulationBody[] jointArticulationBodies;

    //Sets the joints according to the /joint_state topic being published from ROS
    void setJoints(JointStateMsg JointState){          
        //Start from link_1 joint number and go through the remaining links
        for (int i = armStartNum; i < numRobotJoints; i++){
            var xdrive = jointArticulationBodies[i].xDrive;
            // If either of the wrist gripper joints is selected, increase the speed of rotation
             if( i == 12) { 
                xdrive.target = (float)JointState.position[i]*180f/3.1415f*3f; //Convert into degrees
            }
            else if(i == 13) {
                xdrive.target = (float)JointState.position[i]*180f/3.1415f*3f; //Convert into degrees
            }
            else {
                xdrive.target = (float)JointState.position[i]*180f/3.1415f; //Convert into degrees
            } 
            xdrive.target = (float)JointState.position[i]*180f/3.1415f; //Convert into degrees
            jointArticulationBodies[i].xDrive = xdrive; //Set the drive target in degrees for each motor
        }
    }

    // Start is called before the first frame update
    void Start() {
        // Get ROS connection static instance
        ros = ROSConnection.instance;
        //Subscribe to the joint state sensor topic in ROS
        ROSConnection.instance.Subscribe<JointStateMsg>("/joint_states", setJoints);

        //Parts of the robot
        jointArticulationBodies = new ArticulationBody[numRobotJoints];
        
        string l_wheel = "base_link/frame/l_wheel";
        jointArticulationBodies[0] = armstrong.transform.Find(l_wheel).GetComponent<ArticulationBody>();
        string r_wheel = "base_link/frame/r_wheel";
        jointArticulationBodies[1] = armstrong.transform.Find(r_wheel).GetComponent<ArticulationBody>();
        string f_caster_arm = "base_link/frame/f_caster_arm";
        jointArticulationBodies[2] = armstrong.transform.Find(f_caster_arm).GetComponent<ArticulationBody>();
        string f_caster_wheels = "base_link/frame/f_caster_arm/f_caster_wheels";
        jointArticulationBodies[3] = armstrong.transform.Find(f_caster_wheels).GetComponent<ArticulationBody>();
        string b_caster_arm = "base_link/frame/b_caster_arm";
        jointArticulationBodies[4] = armstrong.transform.Find(b_caster_arm).GetComponent<ArticulationBody>();
        string b_caster_wheels = "base_link/frame/b_caster_arm/b_caster_wheels";
        jointArticulationBodies[5] = armstrong.transform.Find(b_caster_wheels).GetComponent<ArticulationBody>();

        //Arm
        string link_1 = "base_link/frame/link_1";
        jointArticulationBodies[6] = armstrong.transform.Find(link_1).GetComponent<ArticulationBody>();
        string link_2 = "base_link/frame/link_1/link_2";
        jointArticulationBodies[7] = armstrong.transform.Find(link_2).GetComponent<ArticulationBody>();
        string link_3 = "base_link/frame/link_1/link_2/link_3";
        jointArticulationBodies[8] = armstrong.transform.Find(link_3).GetComponent<ArticulationBody>();
        string link_4 = "base_link/frame/link_1/link_2/link_3/link_4";
        jointArticulationBodies[9] = armstrong.transform.Find(link_4).GetComponent<ArticulationBody>();
        string link_5 = "base_link/frame/link_1/link_2/link_3/link_4/link_5";
        jointArticulationBodies[10] = armstrong.transform.Find(link_5).GetComponent<ArticulationBody>();
        string link_6 = "base_link/frame/link_1/link_2/link_3/link_4/link_5/link_6";
        jointArticulationBodies[11] = armstrong.transform.Find(link_6).GetComponent<ArticulationBody>();
        string r_finger = "base_link/frame/link_1/link_2/link_3/link_4/link_5/link_6/r_finger";
        jointArticulationBodies[12] = armstrong.transform.Find(r_finger).GetComponent<ArticulationBody>();
        string l_finger = "base_link/frame/link_1/link_2/link_3/link_4/link_5/link_6/l_finger";
        jointArticulationBodies[13] = armstrong.transform.Find(l_finger).GetComponent<ArticulationBody>();
    }
}
