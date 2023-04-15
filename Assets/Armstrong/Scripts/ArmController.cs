using System;
using Unity.Robotics;
using UnityEngine;

public class ArmController : MonoBehaviour {
        public enum ControlType { ArmControl };
        public GameObject armstrong;

        private ArticulationBody[] articulationChain;
        // Stores original colors of the part being highlighted
        //private int startJointNum = 7; //Number of joints associated with the arm
        private int numRobotJoints = 14;
        public ControlType control = ControlType.ArmControl;
        public float stiffness = 10000f;
        public float damping = 100f;
        public float forceLimit = 1000f;
        public float speed = 5f; // Units: degree/s
        public float torque = 100f; // Units: Nm or N
        public float acceleration = 5f;// Units: m/s^2 / degree/s^2

        private ArticulationBody[] jointArticulationBodies;

        void Start()
        {

        jointArticulationBodies = new ArticulationBody[numRobotJoints];
        string link_1 = "base_link/frame/link_1";
        jointArticulationBodies[0] = armstrong.transform.Find(link_1).GetComponent<ArticulationBody>();

        string link_2 = "base_link/frame/link_1/link_2";
        jointArticulationBodies[1] = armstrong.transform.Find(link_2).GetComponent<ArticulationBody>();

        string link_3 = "base_link/frame/link_1/link_2/link_3";
        jointArticulationBodies[2] = armstrong.transform.Find(link_3).GetComponent<ArticulationBody>();

        string link_4 = "base_link/frame/link_1/link_2/link_3/link_4";
        jointArticulationBodies[3] = armstrong.transform.Find(link_4).GetComponent<ArticulationBody>();

        string link_5 = "base_link/frame/link_1/link_2/link_3/link_4/link_5";
        jointArticulationBodies[4] = armstrong.transform.Find(link_5).GetComponent<ArticulationBody>();

        string link_6 = "base_link/frame/link_1/link_2/link_3/link_4/link_5/link_6";
        jointArticulationBodies[5] = armstrong.transform.Find(link_6).GetComponent<ArticulationBody>();

        string r_finger = "base_link/frame/link_1/link_2/link_3/link_4/link_5/link_6/r_finger";
        jointArticulationBodies[6] = armstrong.transform.Find(r_finger).GetComponent<ArticulationBody>();

        string l_finger = "base_link/frame/link_1/link_2/link_3/link_4/link_5/link_6/l_finger";
        jointArticulationBodies[7] = armstrong.transform.Find(l_finger).GetComponent<ArticulationBody>();

        int defDyanmicVal = 10;

        for (int i = 0; i < numRobotJoints; i++){
            jointArticulationBodies[i].gameObject.AddComponent<JointControl>();
            jointArticulationBodies[i].jointFriction = defDyanmicVal;
            jointArticulationBodies[i].angularDamping = defDyanmicVal;
            ArticulationDrive currentDrive = jointArticulationBodies[i].xDrive;
            currentDrive.forceLimit = forceLimit;
            currentDrive.damping = damping;
            currentDrive.stiffness = stiffness;
            jointArticulationBodies[i].xDrive = currentDrive;
        }

    }
}
