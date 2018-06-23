using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beeQueenInterractions : MonoBehaviour {

    public GameObject player;
    public GameObject honeybeeAI;
    public Text queenInterractionInformation;
    AudioSource queenScream;
	// Use this for initialization
	void Start () {
        queenInterractionInformation.text = "";
        queenScream = gameObject.GetComponentInChildren<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            queenInterractionInformation.text = "Press R to feed queen";
            if (Input.GetKeyUp(KeyCode.R) && openCraftingWindow.counterValues[1] > 4)
            {
                openCraftingWindow.counterValues[1] -= 5;
                PlayerPrefs.SetInt("honey", openCraftingWindow.counterValues[1]);
                Instantiate(honeybeeAI, transform.position, transform.rotation);
                queenScream.Play();
            }
        } else
            queenInterractionInformation.text = "";

    }
}
