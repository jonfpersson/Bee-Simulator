using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterBeeHive : MonoBehaviour {

    public GameObject hive;
    public GameObject enterHiveMsg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3.Distance(followPointCoordinate, transform.position)

        if(Vector3.Distance(hive.transform.position, transform.position) < 5)
        {
            enterHiveMsg.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(enterHive());
                enterHiveMsg.SetActive(false);

            }

        } else
            enterHiveMsg.SetActive(false);

        //Debug.Log("HIVE: " + hive.transform.position);
        //Debug.Log("player: " + transform.position);

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
