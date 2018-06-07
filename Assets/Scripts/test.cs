using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public GameObject[] pictures;
    float step;
    Vector3 picPos0;
    Vector3 picPos1;
    Vector3 picPos2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        picPos0 = pictures[0].transform.position;
        Debug.Log("picpos0: " + picPos0);
        picPos1 = pictures[1].transform.position;
        picPos2 = pictures[2].transform.position;


        StartCoroutine(moveObjects());


    }

    private IEnumerator moveObjects()
    {
        float waitTime = 0.04f;
        //small number to make it smooth, 0.04 makes it execute 25 times / sec

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //use WaitForSecondsRealtime if you want it to be unaffected by timescale
            float step = 2 * waitTime;
            if (picPos1 != null && picPos2 != null && picPos0 != null)
            {
                pictures[2].transform.localPosition = Vector3.MoveTowards(transform.position, picPos1, step);
                Debug.Log("picpos0: 1" + picPos0);

                // pictures[1].transform.localPosition = Vector3.MoveTowards(transform.position, picPos0, 3 * Time.deltaTime);
                // pictures[0].transform.localPosition = Vector3.MoveTowards(transform.position, picPos2, 3 * Time.deltaTime);
                Debug.Log("picpos0: 2" + picPos0);

            }


        }
    }

}
