using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openEscMenu : MonoBehaviour {
    public static bool menuIsActivated;
    public GameObject menu;
    // Use this for initialization
    void Start () {
        menuIsActivated = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuIsActivated = !menuIsActivated;
            Screen.lockCursor = !menuIsActivated;
            beeFly.WindowIsActivated = menuIsActivated;
            menu.SetActive(menuIsActivated);

        }
    }
}
