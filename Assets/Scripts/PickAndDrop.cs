using UnityEngine;
using System.Collections;

public class PickAndDrop : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;


    GameObject GetMouseHoverObject(float range)
    {

        Vector3 position = gameObject.transform.position;
        position.y = position.y;
        RaycastHit raycastHit;
        Vector3 target = position + gameObject.transform.forward * range;
        Debug.Log("pos " + position);

        if (Physics.Linecast(position, target, out raycastHit)) { }
        return raycastHit.collider.gameObject;
        return null;
    }

    void tryGrabObject(GameObject grapObject)
    {
        if (grapObject == null || !canGrab(grapObject))
            return;

        grabbedObject = grapObject;
        grabbedObjectSize = grapObject.GetComponent<Renderer>().bounds.size.magnitude * 1;

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
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        grabbedObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObject == null)
                tryGrabObject(GetMouseHoverObject(10));
            else
                dropObject();
        }
        if (grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize + (gameObject.transform.up - new Vector3(0,1,0)) * (grabbedObjectSize * 0.8f);
            grabbedObject.transform.position = newPosition;
        }


    }
}
