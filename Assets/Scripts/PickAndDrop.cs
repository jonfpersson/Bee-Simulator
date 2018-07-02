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

    public Material[] materials;

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
            return true;
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

        //Calculates rotation
        Vector3 rot = transform.parent.parent.rotation.eulerAngles;
        rot = new Vector3(90, rot.y + 90, 0);
        hexagon.transform.rotation = Quaternion.Euler(rot);


        if (grabbedObject != null)
        {
    
            //Moves the object to a position relative to the players camera
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward*0.85f * grabbedObjectSize * 10.2f;
            grabbedObject.transform.parent.parent.position = newPosition;
            grabbedObject.transform.parent.parent.rotation = Quaternion.Euler(rot);

            Debug.Log("after pos: "+gameObject.transform.position + Camera.main.transform.forward * 0.85f * grabbedObjectSize * 10.2f);
        }


        if (Input.GetKeyUp(KeyCode.Alpha3) && openCraftingWindow.counterValues[0] > 0)
        {
            Debug.Log("test");
            Instantiate(hexagon, transform.position + (transform.forward * 1.2f) + transform.up * 0.6f, hexagon.transform.rotation);
            openCraftingWindow.counterValues[0]--;
            PlayerPrefs.SetInt("beeHives", openCraftingWindow.counterValues[0]);

        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            pickUpNectar.nectars = 100;
            openCraftingWindow.counterValues[0] = 1000;
        }


        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * 20;

        
            if (Physics.Linecast(position, target, out raycastHit)
            && raycastHit.collider.name == "hexagonCollider")
            {
                honeyInfo.text = "Press \"2\" to use honey";
                if (Input.GetKeyUp(KeyCode.Alpha2))
                {
                    

                    if (raycastHit.collider.GetComponent<Renderer>().sharedMaterial == materials[0])
                    {
                        //takes Honey
                        raycastHit.transform.parent.parent.gameObject.tag = "honeyComb";
                        openCraftingWindow.counterValues[1]++;
                        PlayerPrefs.SetInt("honey", openCraftingWindow.counterValues[1]);
                        raycastHit.collider.GetComponent<Renderer>().sharedMaterial = materials[1];

                    }
                    else if (raycastHit.collider.GetComponent<Renderer>().sharedMaterial == materials[1] && openCraftingWindow.counterValues[1] > 0)
                    {
                        //leaves honey
                        raycastHit.transform.parent.parent.gameObject.tag = "filledHoneyComb";
                        openCraftingWindow.counterValues[1]--;
                        PlayerPrefs.SetInt("honey", openCraftingWindow.counterValues[1]);
                        raycastHit.collider.GetComponent<Renderer>().sharedMaterial = materials[0];
                    }
                    else
                        honeyInfo.text = "";
                    //Lay honey
                    Debug.Log(raycastHit.collider.GetComponent<Renderer>().sharedMaterial);
                }

            }
            else
                honeyInfo.text = "";

        
    }
}
