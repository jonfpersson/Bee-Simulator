using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateIcons : MonoBehaviour {

    public GameObject[] pictures;

    public GameObject[] levels;

    Vector3 picPos0;
    Vector3 picPos1;
    Vector3 picPos2;

    public static int iconIsMain;

    public void start()
    {
        //Game starts with icon 1 selected
        iconIsMain = 0;


    }

    public void rotatePictures(string direction)
    {

        picPos0 = pictures[0].transform.position;
        picPos1 = pictures[1].transform.position;
        picPos2 = pictures[2].transform.position;

        if (direction == "left")
        {
            //Is left

            pictures[2].transform.position = picPos1;
            pictures[1].transform.position = picPos0;
            pictures[0].transform.position = picPos2;



        }
        else if (direction == "right")
        {
            //Is right
            pictures[2].transform.position = picPos0;
            pictures[1].transform.position = picPos2;
            pictures[0].transform.position = picPos1;


        }


        if (pictures[0].transform.localPosition == new Vector3(-120, 52, 0))
        {
            iconIsMain = 0;
            levels[2].SetActive(true);

            levels[0].SetActive(false);
            levels[1].SetActive(false);
            levels[3].SetActive(false);

        }
        else if (pictures[1].transform.localPosition == new Vector3(-120, 52, 0))
        {
            iconIsMain = 1;
            levels[3].SetActive(true);

            levels[0].SetActive(false);
            levels[1].SetActive(false);
            levels[2].SetActive(false);

        }
        else if (pictures[2].transform.localPosition == new Vector3(-120, 52, 0))
        {
            iconIsMain = 2;
            levels[0].SetActive(true);

            for(int i = 1; i < levels.Length; i++)
            {
                levels[i].SetActive(false);

            }

        }


    }

 /*  private IEnumerator moveObjects()
    {
        float waitTime = 0.04f;
        //small number to make it smooth, 0.04 makes it execute 25 times / sec

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //use WaitForSecondsRealtime if you want it to be unaffected by timescale
            float step = 2 * waitTime;
            if(picPos1 != null && picPos2 != null && picPos0 != null)
            {
                pictures[2].transform.localPosition = Vector3.MoveTowards(transform.position, picPos1, step);
                Debug.Log("picpos0: 1" + picPos0);

               // pictures[1].transform.localPosition = Vector3.MoveTowards(transform.position, picPos0, 3 * Time.deltaTime);
               // pictures[0].transform.localPosition = Vector3.MoveTowards(transform.position, picPos2, 3 * Time.deltaTime);
                Debug.Log("picpos0: 2" + picPos0);

            }


        }
    }
    */


}


