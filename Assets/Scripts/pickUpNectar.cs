using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpNectar : MonoBehaviour {

    float maxDistance = 10;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {


        // Will contain the information of which object the raycast hit
        RaycastHit hit;
        
        float thickness = 1f; //<-- Desired thickness here.
        Vector3 origin = transform.position + new Vector3(0, 0.6f, -1.6f);
        Vector3 direction = transform.TransformDirection(Vector3.forward);
                    
        if (Physics.SphereCast(origin, thickness, direction, out hit) && hit.collider.name == "flower")
        {
            Debug.Log("hit");


        }
      //  Debug.Log(hit.collider.name);



    }

}
