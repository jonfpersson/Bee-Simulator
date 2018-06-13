﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitBeeHive : MonoBehaviour
{
    public GameObject door;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(door.transform.position, transform.position) < 5)
        {
            //Debug.Log("isClose");
            //enterHiveMsg.text = "Press E to exit beehive";
            if (Input.GetKey(KeyCode.G))
            {
                StartCoroutine(ExitHive());

            }
        }
    }

    IEnumerator ExitHive()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Bee Simulator");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }


}




