using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class craftButton : MonoBehaviour {

    public Text[] itemCounters;
    public int[] counterValues;

    // Use this for initialization
    void Start () {
        counterValues = new int[3];

        for (int i = 0; i < counterValues.Length; i++)
        {
            counterValues[i] = 0;
        }
        Debug.Log("Done!");

        counterValues[0] = PlayerPrefs.GetInt("beeHives");
        counterValues[1] = PlayerPrefs.GetInt("honey");
        counterValues[2] = PlayerPrefs.GetInt("royalJelly");

        itemCounters[0].text = PlayerPrefs.GetInt("beeHives").ToString();
        itemCounters[1].text = PlayerPrefs.GetInt("honey").ToString();
        itemCounters[2].text = PlayerPrefs.GetInt("royalJelly").ToString();

    }

    // Update is called once per frame
    void Update () {
		

	}

    public void onPressed()
    {
        if(rotateIcons.iconIsMain == 0 && !(pickUpNectar.nectars -10 < 0))
        {
            Debug.Log("Beehive bought!");
            pickUpNectar.nectars -= 10;
            counterValues[0]++;
            itemCounters[0].text = counterValues[0].ToString();

            //Handels saving data
            PlayerPrefs.SetInt("beeHives", counterValues[0]);
            PlayerPrefs.SetInt("nectars", pickUpNectar.nectars);


        }
        else if (rotateIcons.iconIsMain == 1 && !(pickUpNectar.nectars -5 < 0))
        {
            Debug.Log("honey bought!");
            pickUpNectar.nectars -= 5;
            counterValues[1]++;
            itemCounters[1].text = counterValues[1].ToString();
            
            //Handels saving data
            PlayerPrefs.SetInt("honey", counterValues[1]);
            PlayerPrefs.SetInt("nectars", pickUpNectar.nectars);



        }
        else if (rotateIcons.iconIsMain == 2 && !(pickUpNectar.nectars-20 < 0))
        {
            Debug.Log("Royal jelly bought!");
            pickUpNectar.nectars -= 20;
            counterValues[2]++;
            itemCounters[2].text = counterValues[2].ToString();

            //Handels saving data
            PlayerPrefs.SetInt("nectars", pickUpNectar.nectars);
            PlayerPrefs.SetInt("royalJelly", counterValues[2]);

        }


    }

}
