using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpNectar : MonoBehaviour {

    float maxDistance = 5;
    public Text nectarCounter;
    public static int nectars = 0;
    string informationText = "Nectars: ";
    string maximumText = "/100";
    // Use this for initialization
    void Start () {
        nectars = PlayerPrefs.GetInt("nectars");

        if (nectarCounter != null)
            nectarCounter.text = informationText + nectars.ToString() + maximumText;

    }

    // Update is called once per frame
    void Update()
    {
        if (nectarCounter != null)
            nectarCounter.text = informationText + nectars.ToString() + maximumText;
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) 
            && hit.collider.name== "bigNectar")  {
            if (Input.GetMouseButton(0))
            {
                Destroy(hit.transform.gameObject);
                if(nectars != 100)
                nectars++;
                if (nectarCounter != null)
                    nectarCounter.text = informationText + nectars.ToString() + maximumText;
                PlayerPrefs.SetInt("nectars", nectars);
            }

        }

    }

}
