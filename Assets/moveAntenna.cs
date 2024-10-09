using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAntenna : MonoBehaviour
{
    public float pushForce = 10f; //the force with which the object will be pushed
    private Rigidbody rb; //The Rigidbody component of the object doing the pushing

    // Start is called before the first frame update
    private void Start()
    {
        //Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the colliding object has a Rigidbody component
        Rigidbody otherRB = collision.collider.GetComponent<Rigidbody>();

        //If the colliding object has a Rigidbody component
        if (otherRB != null)
        {
            //Calculate the direction from this object to the colliding object
            Vector3 pushDirection = collision.transform.position - transform.position;

            //Normalize the direction vector to get a unit vector
            pushDirection.Normalize();

            //Apply the push force to the colliding object
            otherRB.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("PickupTarget"))
        {
            // Stop the object's movement temporarily
            rb.isKinematic = true;

            // Adjust the position to avoid overlapping
            Vector3 newPosition = collision.contacts[0].point + collision.contacts[0].normal * 0.1f;
            transform.position = newPosition;

            // Resume the object's movement
            rb.isKinematic = false;
        }
    }
}
