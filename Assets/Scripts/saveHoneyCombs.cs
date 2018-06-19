using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveHoneyCombs : MonoBehaviour {

    public static int numberOfHoneyCombs = 0;
    public static Vector3[] HoneyCombPositions;
    
	// Use this for initialization
	void Start () {
        HoneyCombPositions = new Vector3[numberOfHoneyCombs];
        numberOfHoneyCombs = PlayerPrefs.GetInt("numberOfHoneyCombs");

        for (int i = 0; i < numberOfHoneyCombs; i++)
        {

        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
