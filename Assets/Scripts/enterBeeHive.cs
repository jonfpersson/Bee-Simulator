using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterBeeHive : MonoBehaviour {

    public GameObject hive;
    public Text enterHiveMsg;
    public AudioClip audioPlayer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(hive != null || enterHiveMsg != null)
        {
            if (Vector3.Distance(hive.transform.position, transform.position) < 5)
            {
                //Debug.Log("isClose");
                enterHiveMsg.text = "Press E to enter bee hive";
                if (Input.GetKey(KeyCode.E))
                {
                    StartCoroutine(enterHive());
                    enterHiveMsg.text = "";
                }

            }
            else
                enterHiveMsg.text = "";

        }

    }

    IEnumerator enterHive()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("beeHouse");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
