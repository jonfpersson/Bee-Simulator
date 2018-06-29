using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlVitals : MonoBehaviour
{

    public SimpleHealthBar staminaBar;
    public SimpleHealthBar HealthBar;

    public GameObject diedHUDMenu;
    public Image img;
    
    public GameObject button;

    public AudioListener audioListener;
    public static float stamina, life;
    Color c;
    // Use this for initialization

    void Start()
    {
        stamina = 100;
        life = 100;
        button.SetActive(false);
        c = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            controlPlayerVitals();
        else
            regeneratePlayerVitals();

        if (img != null) {
            c.a = 1 - (life / 100);
            img.color = c;
        }

        if (life < 0){
            die();
        }
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
            beeFly.fastMoveFactor = 1.4f;
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

    public void die()
    {
        Screen.lockCursor = false;

        diedHUDMenu.SetActive(true);
        button.SetActive(true);
        audioListener.enabled = false;
    }
}
