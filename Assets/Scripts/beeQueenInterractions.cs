using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beeQueenInterractions : MonoBehaviour {

    public GameObject player;
    public GameObject honeybeeAI;
    public Text queenInterractionInformation;
    public Text cantFly;
    AudioSource queenScream;
    public SimpleHealthBar healthBar;

    public static float queenHealth;

    // Use this for initialization
    void Start () {
        InvokeRepeating("loseHealth", 0, 1.0f);

        if (PlayerPrefs.GetFloat("queenHealth") == 0)
        {
            queenHealth = 100;
            PlayerPrefs.SetFloat("queenHealth", queenHealth);

        }
        else
            queenHealth = PlayerPrefs.GetFloat("queenHealth");

        queenInterractionInformation.text = "";
        queenScream = gameObject.GetComponentInChildren<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            queenInterractionInformation.text = "Press R to feed 5 honeys to queen \n Or press 1 to feed 1 royaljelly to increase her health";
            if (Input.GetKeyUp(KeyCode.R) && openCraftingWindow.counterValues[1] > 4)
            {
                openCraftingWindow.counterValues[1] -= 5;
                PlayerPrefs.SetInt("honey", openCraftingWindow.counterValues[1]);
                Instantiate(honeybeeAI, transform.position, transform.rotation);
                queenScream.Play();
            }

            if (Input.GetKeyUp(KeyCode.Alpha1) && openCraftingWindow.counterValues[2] > 0)
            {
                openCraftingWindow.counterValues[2] -= 1;
                PlayerPrefs.SetInt("royalJelly", openCraftingWindow.counterValues[2]);
                queenHealth += 50;

                if (queenHealth > 100)
                {
                    queenHealth = 100;
                }
                PlayerPrefs.SetFloat("queenHealth", queenHealth);

            }
        } else
            queenInterractionInformation.text = "";

        if (queenHealth <=0)
        {
            //cantFly.text = "Your queen is dead, you have become depressed. \n Revive her to start your hive up again";
            honeyBeeAI.speed = 0.4f;
            beeFly.normalMoveSpeed = 1;

        }
        else
        {
            honeyBeeAI.speed = 2.5f;
            beeFly.normalMoveSpeed = 10;

        }

    /*    if (Input.GetKeyUp(KeyCode.V))
        {
            queenHealth = 0;
            PlayerPrefs.SetFloat("queenHealth", queenHealth);

        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            queenHealth = 100;
            PlayerPrefs.SetFloat("queenHealth", queenHealth);

        }*/
    }

    public void loseHealth()
    {
        queenHealth = PlayerPrefs.GetFloat("queenHealth");
        queenHealth -= 0.166f;
        PlayerPrefs.SetFloat("queenHealth", queenHealth);
        healthBar.UpdateBar(queenHealth, 100);

    }

}
