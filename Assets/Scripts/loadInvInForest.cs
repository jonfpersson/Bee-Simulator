using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadInvInForest : MonoBehaviour {

    public Text[] itemCounters;
    int[] counterValues;

    // Use this for initialization
    void Start () {
        counterValues = new int[3];
        counterValues[0] = PlayerPrefs.GetInt("beeHives");
        counterValues[1] = PlayerPrefs.GetInt("honey");
        counterValues[2] = PlayerPrefs.GetInt("royalJelly");

    }

    // Update is called once per frame
    void Update()
    {
        
        itemCounters[0].text = PlayerPrefs.GetInt("beeHives").ToString();
        itemCounters[1].text = PlayerPrefs.GetInt("honey").ToString();
        itemCounters[2].text = PlayerPrefs.GetInt("royalJelly").ToString();

        if (Input.GetKeyUp(KeyCode.Alpha2) && counterValues[1] > 0)
        {
            counterValues[1]--;
            PlayerPrefs.SetInt("honey", counterValues[1]);
            controlVitals.stamina = 100;
        }
    }
}
