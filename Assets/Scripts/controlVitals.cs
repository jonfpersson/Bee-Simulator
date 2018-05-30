using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlVitals : MonoBehaviour {

    public SimpleHealthBar healthBar;

    float life, max;
    
    // Use this for initialization
    void Start () {
		max = 100;
		life = 100;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            InvokeRepeating("controlPlayerStamina", 0, .05f);
            Debug.Log("in0");

        }

       
        //InvokeRepeating("setPlayerStamina", 0, .05f);
    }

    public void controlPlayerStamina()
    {
        //Decrease stamina when running
        if (life == 0)
        {
            beeFly.fastMoveFactor = 1;
        } else
        {
            beeFly.fastMoveFactor = 3;
            life--;
            healthBar.UpdateBar(life, 100);

        }
    }

    public void regeneratePlayerStamina()
    {

        Debug.Log("in");
        
    }
}
