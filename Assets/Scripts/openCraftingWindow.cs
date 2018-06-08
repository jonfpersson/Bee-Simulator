using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCraftingWindow : MonoBehaviour {

    public GameObject window;
    bool isActivated;
    // Use this for initialization
	void Start () {
        isActivated = false;

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
