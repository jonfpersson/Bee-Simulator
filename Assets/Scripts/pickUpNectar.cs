using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpNectar : MonoBehaviour {

    float maxDistance = 5;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) 
            && hit.collider.name== "bigNectar")        {
            if (Input.GetMouseButton(0))
                Destroy(hit.transform.gameObject);
        }

        //Debug.Log(hit.collider.name);



    }

}
