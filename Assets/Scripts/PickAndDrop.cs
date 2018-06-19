using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickAndDrop : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;

    public GameObject hexagon;
    public GameObject honeyBall;
    public Text honeyInfo;

    // Use this for initialization
    void Start()
    {
        honeyInfo.text = "";
    }

    GameObject GetMouseHoverObject(float range)
    {

        Vector3 position = gameObject.transform.position;
        //position.y = position.y + 2;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

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
        //return candidate.GetComponent<Rigidbody>() != null;
        if (candidate.layer == 9)
        {
            honeyInfo.text = "Press \"2\" to store honey";
            return true;

        }

        honeyInfo.text = "";
        return false;
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
        if (Input.GetKeyUp(KeyCode.T))
        {
            if (grabbedObject == null)
                tryGrabObject(GetMouseHoverObject(10));
            else
                dropObject();
        }

        Vector3 rot = transform.parent.parent.rotation.eulerAngles;
        rot = new Vector3(90, rot.y + 90, 0);
        hexagon.transform.rotation = Quaternion.Euler(rot);


        if (grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward*0.85f * grabbedObjectSize * 10.2f;
            grabbedObject.transform.parent.parent.position = newPosition;
            grabbedObject.transform.parent.parent.rotation = Quaternion.Euler(rot);
        }

      
       if (Input.GetKeyUp(KeyCode.Alpha3) && openCraftingWindow.counterValues[0] > 0)
        {
            //Vector3 objPos = transform.position + (transform.forward * 1.2f) + transform.up * 0.6f;
            Debug.Log("test");
            Instantiate(hexagon, transform.position + (transform.forward * 1.2f) + transform.up * 0.6f, hexagon.transform.rotation);
            openCraftingWindow.counterValues[0]--;
            PlayerPrefs.SetInt("beeHives", openCraftingWindow.counterValues[0]);

           /* saveHoneyCombs.numberOfHoneyCombs++;
            PlayerPrefs.SetInt("numberOfHoneyCombs", saveHoneyCombs.numberOfHoneyCombs);
            saveHoneyCombs.HoneyCombPositions[saveHoneyCombs.numberOfHoneyCombs] = objPos;
            */

        }

       if (Input.GetKeyUp(KeyCode.Alpha2)) {

        }


        if (Input.GetKeyUp(KeyCode.L))
        {
            pickUpNectar.nectars = 100;
        }

    }
}
