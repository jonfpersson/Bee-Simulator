using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openCraftingWindow : MonoBehaviour {
    public Text[] itemCounters;

    public GameObject window;
    bool isActivated;
    // Use this for initialization
	void Start () {
        itemCounters[0].text = PlayerPrefs.GetInt("beeHives").ToString();
        itemCounters[1].text = PlayerPrefs.GetInt("honey").ToString();
        itemCounters[2].text = PlayerPrefs.GetInt("royalJelly").ToString();


        isActivated = false;
        rotateIcons.iconIsMain = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActivated = !isActivated;
            Screen.lockCursor = !isActivated;
            beeFly.craftingWindowIsActivated = isActivated;
            window.SetActive(isActivated);

        }
    }
}
