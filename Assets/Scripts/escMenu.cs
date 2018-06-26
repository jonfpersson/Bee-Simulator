using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escMenu : MonoBehaviour {

    public GameObject menu;

	// Use this for initialization
	void Start () {
        //menu = GameObject.Find("Canvas/EscMenu");
    }
	
	public void resumeGame()
    {
        menu.SetActive(false);
        beeFly.WindowIsActivated = false;
        Screen.lockCursor = true;
        openEscMenu.menuIsActivated = !openEscMenu.menuIsActivated;

    }

    public void settings()
    {
        //Comming soon
    }

}
