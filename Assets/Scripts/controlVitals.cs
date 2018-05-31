using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlVitals : MonoBehaviour {

    public SimpleHealthBar staminaBar;
    public SimpleHealthBar HealthBar;

    float stamina, max, life;
    
    // Use this for initialization
    void Start () {
		max = 100;
		stamina = 100;
        life = 100;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controlPlayerVitals();
        }
        else
            regeneratePlayerVitals();
    }

    public void controlPlayerVitals()
    {
        //Decrease stamina when running
        if (stamina > 0)
        {
            beeFly.fastMoveFactor = 3;
            stamina -= Time.deltaTime * 24;
            staminaBar.UpdateBar(stamina, 100);

        }
        else
        {
            beeFly.fastMoveFactor = 1;
            life -= Time.deltaTime * 10;
            HealthBar.UpdateBar(life, 100);


        }

    }

    public void regeneratePlayerVitals()
    {
        if (stamina <= 100 && stamina >= -10)
        {
            stamina += Time.deltaTime * 24;
            staminaBar.UpdateBar(stamina, 100);


        }

        if (life <= 100 && life >= -10)
        {
            life += Time.deltaTime * 4;
            HealthBar.UpdateBar(life, 100);

        }

    }
}
