using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpNectar : MonoBehaviour {

    float maxDistance = 5;
    public Text nectarCounter;
    public static int nectars = 0;
    string informationText = "Nectars: ";
    // Use this for initialization
    void Start () {
        nectars = PlayerPrefs.GetInt("nectars");

        if (nectarCounter != null)
            nectarCounter.text = informationText + nectars.ToString() + "/20";

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) 
            && hit.collider.name== "bigNectar")  {
            if (Input.GetMouseButton(0))
            {
                Destroy(hit.transform.gameObject);
                if(nectars != 20)
                nectars++;
                if (nectarCounter != null)
                    nectarCounter.text = informationText + nectars.ToString() + "/20";

            }

        }

    }

}
