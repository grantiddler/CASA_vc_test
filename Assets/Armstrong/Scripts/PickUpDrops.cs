/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    
    private ObjectGrabble objectGrabble;

    // Update is called once per frame
    private void Update() {
        //Not carrying an object, try to grab
        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectGrabble == null) {
                float pickUpDistance = 4f;
                if (Physics.RayCast(playerCameraTransform, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask)) {
                    if (raycastHit.transform.TryGetComponent(out objectGrabble)) {
                        obejctGrabble.Grab(objectGrabPointTransform);
                    }
                }
            } else {
                //Currently carrying something, drop
                objectGrabble.Drop();
                obejctGrabble = null;
            }
        }
        }
}
*/