using UnityEngine;
using System.Collections;

public class PickAndDrop : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;


    GameObject GetMouseHoverObject(float range)
    {

        Vector3 position = gameObject.transform.position;
        //position.y = position.y + 2;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        Debug.Log("pos " + position);

        if (Physics.Linecast(position, target, out raycastHit)) //{ }
            return raycastHit.collider.gameObject;
        return null;
    }

    void tryGrabObject(GameObject grapObject)
    {
        if (grapObject == null || !canGrab(grapObject))
            return;

        grabbedObject = grapObject;
        grabbedObjectSize = grapObject.GetComponent<Renderer>().bounds.size.magnitude;
        //Debug.Log("Taken");
    }

    bool canGrab(GameObject candidate)
    {
        return candidate.GetComponent<Rigidbody>() != null;

    }

    void dropObject()
    {
        if (grabbedObject == null)
            return;

        if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            grabbedObject.GetComponent<Rigidbody>().freezeRotation = true;

        }

        grabbedObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            if (grabbedObject == null)
                tryGrabObject(GetMouseHoverObject(10));
            else
                dropObject();
        }

        if (grabbedObject != null)
        {
            //Debug.Log("grabbed pos" + grabbedObject.transform.position);

            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPosition;
            /*Debug.Log("grabbed pos After" + grabbedObject.transform.position);

            Debug.Log("gameObject.transform.position: " + gameObject.transform.position);
            Debug.Log("Camera.main.transform.forward * grabbedObjectSize: " + Camera.main.transform.forward * grabbedObjectSize);
            Debug.Log("Camera.main.transform.up * grabbedObjectSize: " + Camera.main.transform.up * grabbedObjectSize);
            */
        }


    }
}
