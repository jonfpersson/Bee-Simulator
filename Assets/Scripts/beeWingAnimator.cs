using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeWingAnimator : MonoBehaviour {

    Animator wingAnimator;


    // Use this for initialization
    void Start () {
        wingAnimator = gameObject.GetComponent<Animator>();
        wingAnimator.Play("play");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
