using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class craftButton : MonoBehaviour {

    public Text[] itemCounters;
   

    // Use this for initialization
    void Start () {

        for (int i = 0; i < openCraftingWindow.counterValues.Length; i++)
        {
            openCraftingWindow.counterValues[i] = 0;
        }
        Debug.Log("Done!");

       
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
            openCraftingWindow.counterValues[0]++;
            itemCounters[0].text = openCraftingWindow.counterValues[0].ToString();

            //Handels saving data
            PlayerPrefs.SetInt("beeHives", openCraftingWindow.counterValues[0]);
            PlayerPrefs.SetInt("nectars", pickUpNectar.nectars);


        }
        else if (rotateIcons.iconIsMain == 1 && !(pickUpNectar.nectars -5 < 0))
        {
            Debug.Log("honey bought!");
            pickUpNectar.nectars -= 5;
            openCraftingWindow.counterValues[1]++;
            itemCounters[1].text = openCraftingWindow.counterValues[1].ToString();
            
            //Handels saving data
            PlayerPrefs.SetInt("honey", openCraftingWindow.counterValues[1]);
            PlayerPrefs.SetInt("nectars", pickUpNectar.nectars);



        }
        else if (rotateIcons.iconIsMain == 2 && !(pickUpNectar.nectars-20 < 0))
        {
            Debug.Log("Royal jelly bought!");
            pickUpNectar.nectars -= 20;
            openCraftingWindow.counterValues[2]++;
            itemCounters[2].text = openCraftingWindow.counterValues[2].ToString();

            //Handels saving data
            PlayerPrefs.SetInt("nectars", pickUpNectar.nectars);
            PlayerPrefs.SetInt("royalJelly", openCraftingWindow.counterValues[2]);

        }


    }

}
