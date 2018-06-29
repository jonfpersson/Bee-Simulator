using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diedHUD : MonoBehaviour {

    public GameObject diedHUDMenu;
    public GameObject button;

    // Use this for initialization
    void Start () {
		
	}

    public void reborn()
    {
        StartCoroutine(enterHive());
        diedHUDMenu.SetActive(false);
        button.SetActive(false);
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
