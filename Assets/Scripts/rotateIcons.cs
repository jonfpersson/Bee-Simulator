using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateIcons : MonoBehaviour {

    public GameObject[] pictures;
    public void rotatePictures(string direction)
    {
        Vector3 picPos0 = pictures[0].transform.position;
        Vector3 picPos1 = pictures[1].transform.position;
        Vector3 picPos2 = pictures[2].transform.position;
        if (direction == "left")
        {
            //Is left
            pictures[2].transform.position = picPos0;

        }
        else if (direction == "right")
        {
            //Is right


        }

    }


}


